using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.CrossPlatformInput;

// Shows a structure preview
public class StructureBuilderPreviewView : MonoBehaviour
{
    [SerializeField] private StructureBuilderData _structureBuilder;

    private ToolData _previewTool;
    private PlaceableStructure _previewObject;

    private void Update()
    {
        if (_structureBuilder == null)
            return;

        var builder = _structureBuilder.Instance;
        UpdatePreviewObject(builder.SelectedTool);
        PlacePreview(builder.Settings.PlacementDistance);

        // - Controls -
        if (CrossPlatformInputManager.GetButtonDown(builder.Settings.RotateKey))
        {
            RotatePreview();
        }

        if (CrossPlatformInputManager.GetButtonDown(builder.Settings.PlaceKey)
            && _previewObject != null && _previewObject.IsCanBePlacedHere)
        {
            builder.PlaceStructure(builder.SelectedTool,
                _previewObject.transform.position, _previewObject.transform.rotation);
        }
    }

    private void UpdatePreviewObject(ToolData tool)
    {
        if (_previewTool == tool)
            return;

        if (_previewObject != null)
        {
            Destroy(_previewObject.gameObject);
            _previewObject = null;
        }

        _previewTool = tool;

        if (_previewTool == null)
            return;

        _previewObject = Instantiate(_previewTool.Prefab, transform)
            .GetComponent<PlaceableStructure>();
        _previewObject.ViewMode = StructureViewMode.Preview;
    }

    private void PlacePreview(float distance)
    {
        if (_previewObject == null)
            return;

        var pointerPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distance));
        _previewObject.SetPosition(pointerPosition);
    }

    private void RotatePreview()
    {
        if (_previewObject == null)
            return;

        _previewObject.Rotate();
    }
}
