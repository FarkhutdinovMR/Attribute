using System;
using UnityEngine;

[Serializable]
public class Attribute : IAttribute
{
    [field: SerializeField] public AttributeType Type { get; private set; }
    [field: SerializeField] public uint BaseValue { get; private set; }
    [field: SerializeReference] public ILevel Level { get; private set; }

    public Attribute(AttributeType type, uint baseValue, ILevel level)
    {
        Type = type;
        BaseValue = baseValue;
        Level = level ?? throw new ArgumentNullException(nameof(level));
    }

    public float Value => BaseValue * Level.Value;
}