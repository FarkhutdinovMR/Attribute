using TMPro;
using UnityEngine;

public class DamageHitView : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;

    public void Init(string text)
    {
        _valueText.SetText(text);
    }
}