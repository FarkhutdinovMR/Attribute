using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour, IWalletView
{
    [SerializeField] private TMP_Text _text;

    public void Show(uint money)
    {
        _text.SetText(money.ToString());
    }
}