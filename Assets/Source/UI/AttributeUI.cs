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

    private IAttributeProduct _product;
    private Action<IAttributeProduct> _onBuyButtonClickedCallback;

    public void Init(IAttributeProduct product, Action<IAttributeProduct> onBuyButtonClickedCallback)
    {
        _product = product;
        _onBuyButtonClickedCallback = onBuyButtonClickedCallback;
    }

    public void Show()
    {
        string attributeType = _product.Attribute.Type.ToString();
        _iconImage.sprite = IconLibrary.GetIcon(attributeType);
        _nameText.SetText(attributeType);
        _levelText.SetText($"Lv. {_product.Attribute.Level.Value} / {_product.Attribute.Level.MaxValue}");
        _valueText.SetText(_product.Attribute.Value.ToString());
        _costText.SetText(_product.Attribute.Level.Value != _product.Attribute.Level.MaxValue ? _product.Cost.ToString() : "MaxLv");
    }

    public void OnBuyButtonClick()
    {
        _onBuyButtonClickedCallback?.Invoke(_product);
    }
}