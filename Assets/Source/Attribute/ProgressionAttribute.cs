using System;
using UnityEngine;

[Serializable]
public class ProgressionAttribute : Product, IAttributeProduct
{
    [field: SerializeReference] public IAttribute Attribute { get; private set; }

    public ProgressionAttribute(uint cost, IAttribute attribute) : base(cost)
    {
        Attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
    }

    public override void Buy()
    {
        base.Buy();
        Attribute.Level.LevelUp();
    }
}

public interface IAttributeProduct : IProduct
{
    IAttribute Attribute { get; }
}

[Serializable]
public class FixedAttribute : ILevel, IAttribute, IAttributeProduct
{
    [field: SerializeField] public AttributeType Type { get; private set; }
    [SerializeField] private CostValue[] _costValue;
    [SerializeField] private uint _currentLevel;

    public FixedAttribute(AttributeType type, CostValue[] costValue)
    {
        Type = type;
        _costValue = costValue ?? throw new ArgumentNullException(nameof(costValue));
    }

    public uint Value => _currentLevel + 1;

    public uint MaxValue => (uint)_costValue.Length;

    public ILevel Level => this;

    float IAttribute.Value => _costValue[_currentLevel].Value;

    public IAttribute Attribute => this;

    public uint Cost => _costValue[_currentLevel].Cost;

    public void LevelUp()
    {
        if (_currentLevel + 1 >= MaxValue)
            throw new InvalidOperationException();

        _currentLevel++;
    }

    public void Buy()
    {
        LevelUp();
    }
}

[Serializable]
public class CostValue
{
    public uint Cost;
    public float Value;

    public CostValue(uint cost, float value)
    {
        Cost = cost;
        Value = value;
    }
}