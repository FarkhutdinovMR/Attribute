using UnityEngine;

public class PistolWeaponFactory : MonoBehaviour, IWeaponFactory
{
    [SerializeField] private PistolMB _pistolTemplate;
    [SerializeField] private Transform _weaponContainer;

    private IAttributeProduct[] _defaultAttributes = new ProgressionAttribute[]
    {
        new ProgressionAttribute(5000, new Attribute(AttributeType.Damage, 20, new Level(1, 3))),
        new ProgressionAttribute(2000, new Attribute(AttributeType.RateOfFire, 1, new Level(1, 4))),
        new ProgressionAttribute(3500, new Attribute(AttributeType.ReloadSpeed, 3, new Level(1, 4))),
        new ProgressionAttribute(3000, new Attribute(AttributeType.MagazineSize, 6, new Level(1, 3)))
    };

    public IWeapon Create(IAttributeProduct[] attributes)
    {
        if (attributes == null)
            attributes = _defaultAttributes;

        PistolMB newPistol = Instantiate(_pistolTemplate, _weaponContainer);
        newPistol.Init(attributes);
        return new Pistol(attributes, newPistol);
    }
}

public interface IWeaponFactory
{
    IWeapon Create(IAttributeProduct[] attributes);
}