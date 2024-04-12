using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
   public void SetMaxHealth(float healthValue)
    {
        slider.maxValue = healthValue;
        slider.value = healthValue;
        fill.color = gradient.Evaluate(1f);
        
    }
    public void SetHealth(float healthValue)
    {
        slider.value = healthValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
