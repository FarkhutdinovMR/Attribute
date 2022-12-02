using System;
using UnityEngine;

public class IconLibrary : MonoBehaviour
{
    [SerializeField] private Icon[] _icons;
    [SerializeField] private Sprite _defaultIcon;

    private static Icon[] _iconsStatic;
    private static Sprite _defaultIconStatic;

    private void Awake()
    {
        _iconsStatic = _icons;
        _defaultIconStatic = _defaultIcon;
    }

    public static Sprite GetIcon(string name)
    {
        Icon result = Array.Find(_iconsStatic, icon => icon.Name == name);
        return result != null ? result.Sprite : _defaultIconStatic;
    }
}