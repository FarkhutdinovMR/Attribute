public interface ICharacter
{
    IHealth Health { get; }
    Attribute[] Attributes { get; }
    IWallet Wallet { get; }
    IWeapon[] Weapons { get; }
}