using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIHandler : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Health health;

    private void Start()
    {
        slider.maxValue = health.MaxHP; 
        slider.value = health.CurrentHP;
        health.OnHeal.AddListener(UpdateSlider);
    }

    private void UpdateSlider(float amt)
    {
        slider.value = health.CurrentHP;
    }
}
