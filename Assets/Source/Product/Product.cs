using System;
using UnityEngine;

[Serializable]
public class Product : IProduct
{
    [field: SerializeField] public uint Cost { get; private set; }

    public Product(uint cost)
    {
        Cost = cost;
    }

    public virtual void Buy()
    {
        Cost += Cost;
    }
}