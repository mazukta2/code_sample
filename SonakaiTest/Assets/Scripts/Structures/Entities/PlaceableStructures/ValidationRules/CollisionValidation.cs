using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CollisionValidation : ValidationRule
{
    [SerializeField] private string[] _tags;

    private int _triggerCounter = 0;

    protected void Awake()
    {
        UpdateValidation();
    }

    protected void OnTriggerEnter(Collider other)
    {
        var go = gameObject;
        if (_tags.Any(tag => other.tag == tag))
        {
            _triggerCounter++;
            UpdateValidation();
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (_tags.Any(tag => other.tag == tag))
        {
            _triggerCounter--;
            if (_triggerCounter < 0)
                throw new Exception("Trigger counting error. Trigger counter < 0.");
            UpdateValidation();
        }
    }

    private void UpdateValidation()
    {
        IsValid = _triggerCounter == 0;
    }
}
