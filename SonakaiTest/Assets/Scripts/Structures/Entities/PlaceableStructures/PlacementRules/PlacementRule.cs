using UnityEngine;
using System.Collections;

// Way to place an object.
[DisallowMultipleComponent]
[RequireComponent(typeof(PlaceableStructure))]
public abstract class PlacementRule : MonoBehaviour
{
    // If position is invalid we can't even show a preview of this object.
    public bool IsValid { get; protected set; }

    public abstract void SetPreferredPosition(Vector3 position);
    public abstract void Rotate();
}
