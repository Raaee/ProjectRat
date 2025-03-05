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
        health.OnHurt.AddListener(UpdateSlider);
    }

    private void UpdateSlider(float amt)
    {
        Debug.Log(health.CurrentHP);
        slider.value = health.CurrentHP;
    }
}
