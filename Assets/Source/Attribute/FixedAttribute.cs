using System;
using UnityEngine;

[Serializable]
public class FixedAttribute : Attribute
{
    [SerializeField] private CostValue[] _costValue;
    [field: SerializeReference] private ILevel _level;

    public FixedAttribute(AttributeType type, CostValue[] costValue) : base(type)
    {
        _costValue = costValue;
        _level = new Level(1, (uint)_costValue.Length);
    }

    public override float Value => _costValue[_level.Value - 1].Value;

    public override uint Cost => _costValue[_level.Value - 1].Cost;

    public override ILevel Level => _level;
}