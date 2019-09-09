using UnityEngine;
using System.Collections;

// Check if it possible to create an object in position.
[RequireComponent(typeof(PlaceableStructure))]
public abstract class ValidationRule : MonoBehaviour
{
    public bool IsValid { get; protected set; }
}
