using System;
using UnityEngine;

[Serializable]
public class ValueAttribute : IAttribute
{
    [SerializeField] private readonly float _value;

    public ValueAttribute(float value)
    {
        _value = value;
    }

    public float Value => _value;
}