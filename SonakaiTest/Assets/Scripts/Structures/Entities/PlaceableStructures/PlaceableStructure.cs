using System;
using System.Linq;
using UnityEngine;

// Game logic of a structure.
public class PlaceableStructure : MonoBehaviour
{
    // A preview or in-game object.
    public StructureViewMode ViewMode { get; set; } 

    // Checks if placement rules be able to find a position.
    public bool IsValidPosition => _placementRule ? _placementRule.IsValid : true;

    // And that checks that this position is not collided with something.
    public bool IsCanBePlacedHere => _validationRules.All(r => r.IsValid) && IsValidPosition;

    private PlacementRule _placementRule;
    private ValidationRule[] _validationRules;

    protected void Awake()
    {
        _placementRule = GetComponent<PlacementRule>();
        _validationRules = GetComponents<ValidationRule>();
    }

    public void SetPosition(Vector3 position)
    {
        if (_placementRule != null)
            _placementRule.SetPreferredPosition(position);
        else
            transform.position = position;
    }

    public void Rotate()
    {
        if (_placementRule != null)
            _placementRule.Rotate();
    }
}

