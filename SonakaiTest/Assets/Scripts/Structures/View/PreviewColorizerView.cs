using UnityEngine;
using System.Collections;

// Makes preview red if the structure fails a position validation.
public class PreviewColorizerView : MonoBehaviour
{
    [SerializeField] private PlaceableStructure _placeableStructure;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _deactiveColor;

    private Color _originalColor;

    protected void OnEnable()
    {
        if (_renderer == null)
            return;

        _renderer.material = new Material(_renderer.material);
        _originalColor = _renderer.material.color;
    }

    protected void OnDisable()
    {
        if (_renderer == null)
            return;

        _renderer.material.color = _originalColor;
    }

    protected void Update()
    {
        if (_renderer == null)
            return;

        if (_placeableStructure == null)
            return;

        _renderer.material.color = _placeableStructure.IsCanBePlacedHere ? _activeColor : _deactiveColor;
    }
}
