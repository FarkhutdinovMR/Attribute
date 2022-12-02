using System;
using UnityEngine;

[Serializable]
public class Health : IHealth
{
    [SerializeField] private uint _value;
    [SerializeField] private IAttribute _maxValue;
    private readonly IHealthView _view;

    public Health(uint value, IAttribute maxValue, IHealthView view)
    {
        if (value > maxValue.Value)
            throw new ArgumentOutOfRangeException(nameof(value));

        _value = value;
        _maxValue = maxValue;
        _view = view ?? throw new ArgumentNullException(nameof(view));
    }

    public uint Value => _value;

    public uint MaxValue => (uint)_maxValue.Value;

    public bool IsAlive => Value > 0;

    public void TakeDamage(uint value)
    {
        if (IsAlive == false)
            throw new InvalidOperationException();

        _value = (uint)Math.Clamp((int)_value - value, 0, MaxValue);
        _view.Show(_value, MaxValue);

        if (_value == 0)
            Die();
    }

    public void Heal(uint value)
    {
        _value = Math.Clamp(_value + value, 0, MaxValue);
        _view.Show(_value, MaxValue);
    }

    private void Die() { }
}