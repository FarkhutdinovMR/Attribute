using System;
using UnityEngine;

[Serializable]
public class CostValue
{
    public CostValue(uint cost, float value)
    {
        Cost = cost;
        Value = value;
    }

    [field: SerializeField] public uint Cost { get; private set; }

    [field: SerializeField] public float Value { get; private set; }
}