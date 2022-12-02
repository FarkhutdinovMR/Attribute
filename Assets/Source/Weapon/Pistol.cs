using System;
using UnityEngine;

[Serializable]
public class Pistol : IWeapon
{
    [field: SerializeReference] public Attribute[] Attributes { get; private set; }
    private readonly IWeapon _pistol;

    public Pistol(Attribute[] attributes, IWeapon pistol)
    {
        Attributes = attributes ?? throw new ArgumentNullException(nameof(attributes));
        _pistol = pistol ?? throw new ArgumentNullException(nameof(pistol));
    }

    public void Shoot()
    {
        _pistol.Shoot();
    }
}