using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int MaxHP { get; set; } = 100;
    [field: SerializeField] public int CurrentHP { get; set; } = 0;

    [HideInInspector] public UnityEvent<float> OnHurt;
    [HideInInspector] public UnityEvent<float> OnHeal;
    [HideInInspector] public UnityEvent<GameObject> OnDeath;
<<<<<<< HEAD
=======
    [HideInInspector] public UnityEvent OnDead;
>>>>>>> main

    private void Awake() {
        CurrentHP = MaxHP;
    }
    public void AddHealth(int amt) {
        CurrentHP += amt;
        OnHeal?.Invoke(amt);
        CurrentHP = Mathf.Clamp(CurrentHP, 0, MaxHP);
<<<<<<< HEAD
        Debug.Log("Heal | " + gameObject.name);
=======
>>>>>>> main
    }
    public void RemoveHealth(int amt) {
        CurrentHP -= amt;
        OnHurt?.Invoke(amt);
        CurrentHP = Mathf.Clamp(CurrentHP, 0, MaxHP);
        if (CurrentHP <= 0) {
            Debug.Log("Dead");
            OnDeath.Invoke(this.gameObject);
        }
<<<<<<< HEAD
        Debug.Log("Hurting | " + gameObject.name);

=======
    }

    public void OnPlayerDead() {
        OnDead.Invoke();
>>>>>>> main
    }
}
