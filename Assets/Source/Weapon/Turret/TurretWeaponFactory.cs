using UnityEngine;

public class TurretWeaponFactory : MonoBehaviour, IWeaponFactory
{
    [SerializeField] private TurretMB _turretTemplate;
    [SerializeField] private Transform _weaponContainer;

    private Attribute[] _defaultAttributes = new Attribute[]
    {
        new ProgressionAttribute(AttributeType.Damage, new Level(1, 4), 1000, 10),
        new FixedAttribute(AttributeType.RateOfFire, new CostValue[] { new CostValue(2000, 1), new CostValue(3000, 0.5f), new CostValue(4000, 0.25f) }),
    };

    public Weapon Create(Attribute[] attributes)
    {
        if (attributes == null)
            attributes = _defaultAttributes;

        TurretMB newTurret = Instantiate(_turretTemplate, _weaponContainer);
        newTurret.Init(attributes);
        return new Turret(attributes, newTurret);
    }
}