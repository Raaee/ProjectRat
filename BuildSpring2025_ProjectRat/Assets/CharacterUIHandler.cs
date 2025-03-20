using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIHandler : MonoBehaviour
{
    private AcidOrbs acidOrbs;
    [SerializeField] private Health health;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider orbSlider;

    private void Start()
    {
        acidOrbs = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AcidOrbs>();
        InitBars();
        health.OnHurt.AddListener(UpdateHealthSlider);
        health.OnHeal.AddListener(UpdateHealthSlider);
        acidOrbs.OnOrbUpdate.AddListener(UpdateOrbSlider);
    }
    private void InitBars() {
        healthSlider.maxValue = health.MaxHP;
        healthSlider.value = health.CurrentHP;
        if (orbSlider) orbSlider.maxValue = acidOrbs.maxOrbs;
        if (orbSlider) orbSlider.value = acidOrbs.currentOrbs;
    }

    private void UpdateHealthSlider(float amt)
    {
        healthSlider.value = health.CurrentHP;
    }
    private void UpdateOrbSlider() {
        if (orbSlider) orbSlider.value = acidOrbs.currentOrbs;
    }
}
