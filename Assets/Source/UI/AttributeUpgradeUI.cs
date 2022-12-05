using System;
using System.Collections.Generic;
using UnityEngine;

public class AttributeUpgradeUI : MonoBehaviour
{
    [SerializeField] private AttributeUI _attributeUITemplate;
    [SerializeField] private Transform _attributeUIContainer;
    [SerializeField] private MonoBehaviour _walletViewSource;
    private IWalletView _walletView => (IWalletView)_walletViewSource;

    private IEnumerable<Attribute> _attributes;
    private Action _onSuccessUpgradedCallback;
    private List<AttributeUI> _attributeUIs;
    private IWallet _wallet;

    public void Init(IEnumerable<Attribute> products, IWallet wallet)
    {
        _attributes = products ?? throw new ArgumentNullException(nameof(products));
        _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        _attributeUIs = new List<AttributeUI>();
    }

    public void Show(Action onSuccessUpgradedCallback)
    {
        _onSuccessUpgradedCallback = onSuccessUpgradedCallback;
        Render();
        gameObject.SetActive(true);
    }

    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
    }

    private void Upgrade(Attribute attribute)
    {
        if (_wallet.Money < attribute.Cost)
            return;

        if (attribute.Level.IsMaxReached)
            return;

        _wallet.Spend(attribute.Cost);
        attribute.Upgrade();
        Render();
        _onSuccessUpgradedCallback?.Invoke();
    }

    private void Render()
    {
        _wallet.Show(_walletView);

        if (_attributeUIs.Count > 0)
            Clear();

        foreach (Attribute attribute in _attributes)
        {
            AttributeUI newAttributeUI = Instantiate(_attributeUITemplate, _attributeUIContainer);
            newAttributeUI.Init(attribute, Upgrade);
            newAttributeUI.Show();
            _attributeUIs.Add(newAttributeUI);
        }
    }

    private void Clear()
    {
        foreach (AttributeUI attributeUI in _attributeUIs)
            Destroy(attributeUI.gameObject);

        _attributeUIs.Clear();
    }

    private void OnValidate()
    {
        if (_walletViewSource != null && !(_walletViewSource is IWalletView))
        {
            Debug.LogError(nameof(_walletViewSource) + " is not implement " + nameof(IWalletView));
            _walletViewSource = null;
        }
    }
}