using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, IHealthView
{
    [SerializeField] private Slider _progressBar;
    [SerializeField] private TMP_Text _valueText;

    public void Show(uint value, uint maxValue)
    {
        _progressBar.value = (float)value / maxValue;
        _valueText.SetText($"{value}/{maxValue}");
    }
}