using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Tools/Group")]
public class ToolGroupData : ScriptableObject
{
    public List<ToolData> Tools => _tools;

    [SerializeField] private List<ToolData> _tools;

}
