using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
        PlayerData.maxHealth = health;
        PlayerData.Healthku = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float health){
        slider.maxValue = PlayerData.maxHealth;
        slider.value = health;
        PlayerData.Healthku = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
