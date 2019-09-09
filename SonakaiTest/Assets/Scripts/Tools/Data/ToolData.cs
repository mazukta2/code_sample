using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Tools/Tool")]
public class ToolData : ScriptableObject
{
    public Sprite Icon => _icon;
    public int Number => _number;
    public string Hotkey => _hotkey;
    public PlaceableStructure Prefab => _prefab;

    [SerializeField] private Sprite _icon;
    [SerializeField] public int _number = 1;
    [SerializeField] public string _hotkey = "Select Tool 1";
    [SerializeField] public PlaceableStructure _prefab;
}
