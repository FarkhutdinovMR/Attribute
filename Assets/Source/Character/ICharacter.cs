public interface ICharacter
{
    IHealth Health { get; }
    IAttributeProduct[] Attributes { get; }
    IWallet Wallet { get; }
    IWeapon[] Weapons { get; }
}