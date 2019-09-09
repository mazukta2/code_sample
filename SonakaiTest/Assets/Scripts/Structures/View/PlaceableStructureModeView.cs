using UnityEngine;
using System.Collections;

// Disable certain game objects if the structure in wrong mode.
public class PlaceableStructureModeView : MonoBehaviour
{
    [SerializeField] private PlaceableStructure _structure;
    [SerializeField] private StructureViewMode _mode;
    [SerializeField] private GameObject[] _objects;

    void Update()
    {
        if (_structure == null)
            return;

        if (_objects == null)
            return;

        foreach (var item in _objects)
            item.SetActive(_structure.ViewMode == _mode);
    }
}
