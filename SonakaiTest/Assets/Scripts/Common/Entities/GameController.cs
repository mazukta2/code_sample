using System;
using System.Collections.Generic;
using UnityEngine;

// Main class. Must be execute before others.
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private Dictionary<int, object> _dataSingletons = new Dictionary<int, object>();

    public void Awake()
    {
        Instance = this;
    }

    // Saving links of singleton instances
    public T GetDataSingletonInstance<T>(ScriptableObjectSingletonData<T> provider)
    {
        if (Instance == null)
            throw new Exception("The game is not initiated.");

        object result;
        if (!_dataSingletons.TryGetValue(provider.GetInstanceID(), out result))
        {
            result = provider.CreateInstance(this);
            _dataSingletons.Add(provider.GetInstanceID(), result);
        }

        return (T)result;
    }
}
