using System;

[Serializable]
public class Pistol : Weapon
{
    public Pistol(Attribute[] attributes, IWeapon weapon) : base(attributes, weapon) { }
}