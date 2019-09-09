using UnityEngine;
using System.Collections;

// Keep current structure tool and settings.
public class StructureBuilder 
{
    public ToolData SelectedTool { get; set; }
    public ToolGroupData SelectedToolGroup => Settings.DefauiltToolSet;
    public StructureBuilderData Settings { get; private set; }

    private GameObject _structuresParent;

    public StructureBuilder(StructureBuilderData settings)
    {
        _structuresParent = new GameObject("Structures");
        Settings = settings;
    }

    public void PlaceStructure(ToolData tool, Vector3 position, Quaternion rotation)
    {
        var structure = GameObject.Instantiate(tool.Prefab.gameObject, position, rotation, _structuresParent.transform)
            .GetComponent<PlaceableStructure>();
        structure.ViewMode = StructureViewMode.Ingame;
    }
}
