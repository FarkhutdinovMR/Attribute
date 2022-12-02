using UnityEngine;

public class WeaponFactory : MonoBehaviour
{
    [SerializeField] private PistolWeaponFactory _pistolWeaponFactory;

    public IWeapon Create(IWeapon weapon)
    {
        if (weapon.GetType() == typeof(Pistol))
            return _pistolWeaponFactory.Create(weapon.Attributes);

        return null;
    }

    public IWeapon Create<T>()
    {
        if (typeof(T) == typeof(Pistol))
            return _pistolWeaponFactory.Create(null);

        return null;
    }
}