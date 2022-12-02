public interface IWallet
{
    uint Money { get; }
    void Spend(uint money);
    void Show(IWalletView walletView);
}