using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private CharacterFactory _characterFactory;
    [SerializeField] private CharacterUpgradeUI _characterUpgradeUI;

    private FileSave<ICharacter> _saver;

    public ICharacter Character { get; private set; }

    private void Start()
    {
        _saver = new FileSave<ICharacter>();
        Character = _characterFactory.Create(_saver.Load<Character>());
        _characterUpgradeUI.Init(GetAllAttributes(), Character.Wallet);
        Character.Health.TakeDamage(0);
    }

    public void CharacterUpgrade()
    {
        _characterUpgradeUI.Show(() =>
        {
            _saver.Save(Character);
            Character.Health.TakeDamage(0);
        });
    }

    private void OnApplicationQuit()
    {
        _saver.Save(Character);
    }

    private IEnumerable<IAttributeProduct> GetAllAttributes()
    {
        var attributes = new List<IAttributeProduct>();
        attributes.AddRange(Character.Attributes);
        foreach (IWeapon weapon in Character.Weapons)
            attributes.AddRange(weapon.Attributes);

        return attributes;
    }
}