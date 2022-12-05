using UnityEngine;

public class WeaponFactory : MonoBehaviour
{
    [SerializeField] private PistolWeaponFactory _pistolWeaponFactory;
    [SerializeField] private TurretWeaponFactory _turretWeaponFactory;

    public Weapon Create(Weapon weapon)
    {
        if (weapon.GetType() == typeof(Pistol))
            return _pistolWeaponFactory.Create(weapon.Attributes);
        else if (weapon.GetType() == typeof(Turret))
            return _turretWeaponFactory.Create(weapon.Attributes);

        return null;
    }

    public Weapon Create<T>()
    {
        if (typeof(T) == typeof(Pistol))
            return _pistolWeaponFactory.Create(null);
        else if (typeof(T) == typeof(Turret))
            return _turretWeaponFactory.Create(null);

        return null;
    }
}