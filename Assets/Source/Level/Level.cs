using System;
using UnityEngine;

[Serializable]
public class Level : ILevel
{
    [field: SerializeField] public uint Value { get; private set; }
    [field: SerializeField] public uint MaxValue { get; private set; }

    public Level(uint value, uint maxValue)
    {
        if (value > maxValue)
            throw new ArgumentOutOfRangeException(nameof(value));

        Value = value;
        MaxValue = maxValue;
    }

    public void LevelUp()
    {
        if (Value + 1 > MaxValue)
            throw new InvalidOperationException();

        Value++;
    }
}