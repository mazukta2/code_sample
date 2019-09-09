using UnityEngine;
using UnityEngine.UI;

// A group of tools
[RequireComponent(typeof(ToggleGroup))]
public class ToolGroupSelectorView : MonoBehaviour
{
    public ToggleGroup ToggleGroup { get; private set; }

    [SerializeField] private StructureBuilderData _structureBuilderSettings;
    [SerializeField] private ToolButtonView _buttonPrefab;
    
    protected void Awake()
    {
        ToggleGroup = GetComponent<ToggleGroup>();

        RecreateButtons();
    }

    protected void RecreateButtons()
    {
        if (_structureBuilderSettings == null || _buttonPrefab == null)
            return;

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        var toolsGroup = _structureBuilderSettings.Instance.SelectedToolGroup;
        foreach (var tool in toolsGroup.Tools)
        {
            var button = GameObject.Instantiate(_buttonPrefab.gameObject, transform)
                .GetComponent<ToolButtonView>();
            button.ToolGroupSelector = this;
            button.Tool = tool;
        }
    }

    // A button event of changing a selection status.
    // You can use events, but direct call is safer.
    public void NotifyToolButtonValueChanged(ToolButtonView button, bool value)
    {
        if (_structureBuilderSettings == null)
            return;

        var builder = _structureBuilderSettings.Instance;

        if (value)
            builder.SelectedTool = button.Tool;
        else if (builder.SelectedTool == button.Tool)
            builder.SelectedTool = null;
    }
}
