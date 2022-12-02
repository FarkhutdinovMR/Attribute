using System;
using UnityEngine;

[Serializable]
public class Armor : IHealth
{
    [SerializeField] private uint _value;
    [SerializeField] private IAttribute _maxValue;
    [SerializeField] private IHealth _health;
    private readonly IHealthView _view;

    public Armor(uint value, IAttribute maxValue, IHealth health, IHealthView view)
    {
        _value = value;
        _maxValue = maxValue ?? throw new ArgumentNullException(nameof(maxValue));
        _health = health ?? throw new ArgumentNullException(nameof(health));
        _view = view ?? throw new ArgumentNullException(nameof(view));
    }

    public uint Value => _health.Value;

    public uint MaxValue => _health.MaxValue;

    public void TakeDamage(uint value)
    {
        uint armorDamage = (uint)Mathf.Clamp((int)value, 0, _value);
        _value -= armorDamage;
        _health.TakeDamage(value - armorDamage);
        _view.Show(_value, (uint)_maxValue.Value);
    }
}