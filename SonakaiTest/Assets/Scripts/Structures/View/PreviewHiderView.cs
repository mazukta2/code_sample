using UnityEngine;
using System.Collections;

// Hide preview renderer if the structure in a wrong position.
public class PreviewHiderView : MonoBehaviour
{
    [SerializeField] private PlaceableStructure _placeableStructure;
    [SerializeField] private Renderer _renderer;

    protected void OnDisable()
    {
        if (_renderer == null)
            return;

        _renderer.enabled = true;
    }

    protected void Update()
    {
        if (_placeableStructure == null)
            return;

        if (_renderer == null)
            return;

        _renderer.enabled = _placeableStructure.IsValidPosition;
    }
}
