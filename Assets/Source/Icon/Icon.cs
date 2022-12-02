using System;
using UnityEngine;

[Serializable]
public class Icon
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}