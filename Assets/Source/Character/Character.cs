using System;
using UnityEngine;

[Serializable]
public class Character : ICharacter
{
    [field: SerializeReference] public IHealth Health { get; private set; }
    [field: SerializeReference] public Attribute[] Attributes { get; private set; }
    [field: SerializeReference] public IWallet Wallet { get; private set; }
    [field: SerializeReference] public IWeapon[] Weapons { get; private set; }

    public Character(IHealth health, Attribute[] attributes, IWallet wallet, IWeapon[] weapons)
    {
        Health = health ?? throw new ArgumentNullException(nameof(health));
        Attributes = attributes ?? throw new ArgumentNullException(nameof(attributes));
        Wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
        Weapons = weapons ?? throw new ArgumentNullException(nameof(weapons));
    }
}