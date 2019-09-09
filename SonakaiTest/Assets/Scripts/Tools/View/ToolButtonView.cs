using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Toggle))]
public class ToolButtonView : MonoBehaviour
{
    public ToolData Tool
    {
        get { return _tool; }
        set { _tool = value; }
    }

    public ToolGroupSelectorView ToolGroupSelector
    {
        get { return _toolGroupSelector; }
        set { _toolGroupSelector = value; }
    }

    [SerializeField] private ToolGroupSelectorView _toolGroupSelector;
    [SerializeField] private ToolData _tool;
    [SerializeField] private Text _numberText;
    [SerializeField] private Image _iconImage;

    private Toggle _toggle;

    protected void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(OnSelectedValueChanged);
    }

    protected void OnDestroy()
    {
        _toggle.onValueChanged.RemoveListener(OnSelectedValueChanged);
    }

    protected void Update()
    {
        if (_tool == null)
            return;

        if (_iconImage != null)
            _iconImage.sprite = _tool.Icon;

        if (_numberText != null)
            _numberText.text = _tool.Number.ToString();

        if (_toolGroupSelector != null)
            _toggle.group = _toolGroupSelector.ToggleGroup;

        // - Controls -
        if (_toggle != null && CrossPlatformInputManager.GetButtonDown(_tool.Hotkey))
        {
            _toggle.isOn = !_toggle.isOn;

            // TODO: If something change a tool selection status in entity layer they will be out of sync
        }
    }

    private void OnSelectedValueChanged(bool value)
    {
        if (_toolGroupSelector != null)
            _toolGroupSelector.NotifyToolButtonValueChanged(this, value);
    }
}
