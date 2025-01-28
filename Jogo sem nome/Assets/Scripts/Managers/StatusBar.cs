using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    //[SerializeField] private Slider statusSlider;
    [SerializeField] private Image statusImage;

    public void Initialize(float maxValue)
    {
        statusImage.fillAmount = maxValue;
        //statusSlider.maxValue = maxValue;
        //statusSlider.value = maxValue;
    }

    public void UpdateHealth(float currentValue)
    {
        statusImage.fillAmount = currentValue / 100;
        //statusSlider.value = currentValue;

    }

  
}
