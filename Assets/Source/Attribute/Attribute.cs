using System;
using UnityEngine;

[Serializable]
public abstract class Attribute : IAttribute
{
    [field: SerializeField] public AttributeType Type { get; private set; }

    protected Attribute(AttributeType type)
    {
        Type = type;
    }

    public abstract ILevel Level { get; }
    
    public abstract uint Cost { get; }

    public abstract float Value { get; }

    public virtual void Upgrade()
    {
        Level.LevelUp();
    }
}