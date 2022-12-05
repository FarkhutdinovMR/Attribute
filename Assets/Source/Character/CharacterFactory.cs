using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour, ICharacterFactory
{
    [SerializeField] MonoBehaviour _healthViewSource;
    IHealthView _healthView => (IHealthView)_healthViewSource;

    [SerializeField] MonoBehaviour _armorViewSource;
    IHealthView _armorView => (IHealthView)_armorViewSource;

    [SerializeField] private WeaponFactory _weaponFactory;

    private Attribute[] _defaultAttributes = new Attribute[]
    {
        new FixedAttribute(AttributeType.Health, new CostValue[] { new CostValue(1000, 150), new CostValue(2000, 200), new CostValue(4000, 250) }),
        new FixedAttribute(AttributeType.Armor, new CostValue[] { new CostValue(2000, 50), new CostValue(3000, 75), new CostValue(4000, 100) })
    };

    public ICharacter Create(ICharacter character)
    {
        if (character == null)
            return Create();

        List<Weapon> weapons = new();
        foreach (Weapon weapon in character.Weapons)
            weapons.Add(_weaponFactory.Create(weapon));

        return new Character(CreateHealth(character.Attributes), character.Attributes, character.Wallet, weapons.ToArray());
    }

    private ICharacter Create()
    {
        IWeapon[] weapons = new IWeapon[] { _weaponFactory.Create<Turret>() };
        return new Character(CreateHealth(_defaultAttributes), _defaultAttributes, new Wallet(50000), weapons);
    }

    private IHealth CreateHealth(Attribute[] attributes)
    {
        IAttribute health = Array.Find(attributes, item => item.Type == AttributeType.Health);
        IAttribute armor = Array.Find(attributes, item => item.Type == AttributeType.Armor);
        return new Armor((uint)armor.Value, armor, new Health((uint)health.Value, health, _healthView), _armorView);
    }

    private void OnValidate()
    {
        if (_healthViewSource != null && !(_healthViewSource is IHealthView))
        {
            Debug.LogError(nameof(_healthViewSource) + " is not implement " + nameof(IHealthView));
            _healthViewSource = null;
        }

        if (_armorViewSource != null && !(_armorViewSource is IHealthView))
        {
            Debug.LogError(nameof(_armorViewSource) + " is not implement " + nameof(IHealthView));
            _armorViewSource = null;
        }
    }
}