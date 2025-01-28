using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private Slider statusSlider;

    public void Initialize(float maxValue)
    {
        statusSlider.maxValue = maxValue;
        statusSlider.value = maxValue;
    }

    public void UpdateHealth(float currentValue)
    {
        statusSlider.value = currentValue;
    }
}
