using System;
using UnityEngine;

[Serializable]
public class ProgressionAttribute : Attribute
{
    [SerializeField] private uint _baseValue;
    [SerializeField] private uint _cost;
    [field: SerializeReference] private ILevel _level;

    public ProgressionAttribute(AttributeType type, ILevel level, uint cost, uint baseValue) : base(type)
    {
        _baseValue = baseValue;
        _cost = cost;
        _level = level;
    }

    public override float Value => _baseValue * Level.Value;

    public override uint Cost => _cost;

    public override ILevel Level => _level;

    public override void Upgrade()
    {
        base.Upgrade();
        _cost += _cost;
    }
}