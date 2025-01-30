using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private Slider statusSlider;
    //[SerializeField] private Image statusImage;
    public Gradient gradient;
    public Image ?gradientImage;
    [SerializeField] private TMP_Text valueText;
    private  float maxValueText;
    

    public void Initialize( float maxValue )
    {
        maxValueText = maxValue;
        //statusImage.fillAmount = maxValue;
        valueText.text = $" {maxValue.ToString()} / {maxValue}";
        statusSlider.maxValue = maxValue;
        statusSlider.value = maxValue;

        if(gradientImage != null)
        {
            gradientImage.color = gradient.Evaluate(1f);
        }
    }

    public void UpdateStatus(float currentValue)
    {
        //statusImage.fillAmount = currentValue / 100;
        valueText.text = $" {currentValue.ToString()} / {maxValueText}";
        statusSlider.value = currentValue;

        if(gradientImage != null)
        {
            gradientImage.color = gradient.Evaluate(statusSlider.normalizedValue);
        }
        
        
    }

  
}
