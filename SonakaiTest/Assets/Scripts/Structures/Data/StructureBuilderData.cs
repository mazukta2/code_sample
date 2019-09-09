using UnityEngine;

[CreateAssetMenu(menuName = "Game/Structure/Structure Builder")]
public class StructureBuilderData : ScriptableObjectSingletonData<StructureBuilder>
{
    public ToolGroupData DefauiltToolSet => _defaultToolSet;
    public float PlacementDistance => _placementDistance;
    public string PlaceKey => _placeKey;
    public string RotateKey => _rotateKey;

    [SerializeField] private ToolGroupData _defaultToolSet;
    [SerializeField] private float _placementDistance = 2f;
    [SerializeField] private string _placeKey;
    [SerializeField] private string _rotateKey;

    public override StructureBuilder CreateInstance(GameController gameController)
    {
        return new StructureBuilder(this);
    }
}
