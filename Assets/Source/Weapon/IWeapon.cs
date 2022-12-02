public interface IWeapon
{
    IAttributeProduct[] Attributes { get; }
    void Shoot();
}