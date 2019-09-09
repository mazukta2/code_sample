using UnityEngine;
using System.Collections;

// Provide an access to global entities of the game. 
// A usual singleton or DI can be used instead, 
// but I like to have easy access to editor settings.
public abstract class ScriptableObjectSingletonData<T> : ScriptableObject
{
    public virtual T Instance => GameController.Instance.GetDataSingletonInstance<T>(this);

    public abstract T CreateInstance(GameController gameController);
}
