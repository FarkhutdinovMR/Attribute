using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttributeUI : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private TMP_Text _costText;

    private Attribute _attribute;
    private Action<Attribute> _onBuyButtonClickedCallback;

    public void Init(Attribute attribute, Action<Attribute> onBuyButtonClickedCallback)
    {
        _attribute = attribute;
        _onBuyButtonClickedCallback = onBuyButtonClickedCallback;
    }

    public void Show()
    {
        string attributeType = _attribute.Type.ToString();
        _iconImage.sprite = IconLibrary.GetIcon(attributeType);
        _nameText.SetText(attributeType);
        _levelText.SetText($"Lv. {_attribute.Level.Value} / {_attribute.Level.MaxValue}");
        _valueText.SetText(_attribute.Value.ToString());
        _costText.SetText(_attribute.Level.Value != _attribute.Level.MaxValue ? _attribute.Cost.ToString() : "MaxLv");
    }

    public void OnBuyButtonClick()
    {
        _onBuyButtonClickedCallback?.Invoke(_attribute);
    }
}