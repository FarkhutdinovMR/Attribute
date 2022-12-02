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

    private List<IAttributeProduct> _defaultAttributes = new()
    {
        new FixedAttribute(AttributeType.Health, new CostValue[] { new CostValue(1000, 150), new CostValue(2000, 200), new CostValue(4000, 250) }),
        new ProgressionAttribute(3500, new Attribute(AttributeType.Armor, 50, new Level(1, 5))),
        new ProgressionAttribute(3000, new Attribute(AttributeType.MoveSpeed, 4, new Level(1, 5)))
    };

    public ICharacter Create(ICharacter character)
    {
        if (character == null)
            return Create();

        List<IWeapon> weapons = new();
        foreach (IWeapon weapon in character.Weapons)
            weapons.Add(_weaponFactory.Create(weapon));

        return new Character(CreateHealth(character.Attributes), character.Attributes, character.Wallet, weapons.ToArray());
    }

    private ICharacter Create()
    {
        IWeapon[] weapons = new IWeapon[] { _weaponFactory.Create<Pistol>() };
        return new Character(CreateHealth(_defaultAttributes.ToArray()), _defaultAttributes.ToArray(), new Wallet(50000), weapons);
    }

    private IHealth CreateHealth(IAttributeProduct[] attributes)
    {
        IAttribute health = Array.Find(attributes, item => item.Attribute.Type == AttributeType.Health).Attribute;
        IAttribute armor = Array.Find(attributes, item => item.Attribute.Type == AttributeType.Armor).Attribute;
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