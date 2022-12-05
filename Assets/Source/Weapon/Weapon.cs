using System;
using UnityEngine;

[Serializable]
public class Weapon : IWeapon
{
    [field: SerializeReference] public Attribute[] Attributes { get; private set; }
    private readonly IWeapon _weapon;

    public Weapon(Attribute[] attributes, IWeapon weapon)
    {
        Attributes = attributes ?? throw new ArgumentNullException(nameof(attributes));
        _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
    }

    public void Shoot()
    {
        _weapon.Shoot();
    }
}