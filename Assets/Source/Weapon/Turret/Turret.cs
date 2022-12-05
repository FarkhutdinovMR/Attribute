using System;

[Serializable]
public class Turret : Weapon
{
    public Turret(Attribute[] attributes, IWeapon weapon) : base(attributes, weapon) { }
}