using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int currentHP = 0;

    private void Start() {
        currentHP = maxHP;
    }
    public void AddHealth(int amt) {
        currentHP += amt;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        Debug.Log("Heal | " + gameObject.name);
    }
    public void RemoveHealth(int amt) {
        currentHP -= amt;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        if (currentHP <= 0) {
            Debug.Log("Dead");
        }
        Debug.Log("Hurting | " + gameObject.name);

    }
}
