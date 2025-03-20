using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

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

=======
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
>>>>>>> spriteSlices
    }
}
