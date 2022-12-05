using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private CharacterFactory _characterFactory;
    [SerializeField] private AttributeUpgradeUI _characterUpgradeUI;

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
        _characterUpgradeUI.Show(() => Character.Health.TakeDamage(0));
    }

    private IEnumerable<Attribute> GetAllAttributes()
    {
        var attributes = new List<Attribute>();
        attributes.AddRange(Character.Attributes);
        foreach (Weapon weapon in Character.Weapons)
            attributes.AddRange(weapon.Attributes);

        return attributes;
    }

    private void OnApplicationQuit()
    {
        _saver.Save(Character);
    }
}