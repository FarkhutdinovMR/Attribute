using UnityEngine;

public class PistolWeaponFactory : MonoBehaviour, IWeaponFactory
{
    [SerializeField] private PistolMB _pistolTemplate;
    [SerializeField] private Transform _weaponContainer;

    private Attribute[] _defaultAttributes = new Attribute[]
    {
        new ProgressionAttribute(AttributeType.Damage, new Level(1, 3), 2000, 20),
        new FixedAttribute(AttributeType.RateOfFire, new CostValue[] { new CostValue(2000, 1), new CostValue(3000, 0.5f), new CostValue(4000, 0.25f) }),
    };

    public IWeapon Create(Attribute[] attributes)
    {
        if (attributes == null)
            attributes = _defaultAttributes;

        PistolMB newPistol = Instantiate(_pistolTemplate, _weaponContainer);
        newPistol.Init(attributes);
        return new Pistol(attributes, newPistol);
    }
}