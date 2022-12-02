using System;
using UnityEngine;

public class Wallet : IWallet
{
    [SerializeField] private uint _money;

    public Wallet(uint money)
    {
        _money = money;
    }

    public uint Money => _money;

    public void Spend(uint cost)
    {
        if (_money < cost)
            throw new InvalidOperationException();

        _money -= cost;
    }

    public void Show(IWalletView walletView)
    {
        walletView.Show(_money);
    }
}