using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Properties")]
    public bool isAttacking;
    [Header("Attack Duration (seconds)")]
    public float attackDuration = 5f;

    [SerializeField] private GameObject attackCollider;
    private Actions actions;

    private void Start() {
        attackCollider = GameObject.Find("Attack");
        attackCollider.SetActive(false);

        actions = GetComponent<Actions>();
        actions.OnAttack.AddListener(OnAttack);
    }

    private IEnumerator PerformAttack() {
        isAttacking = true;
        attackCollider.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        isAttacking = false;
        attackCollider.SetActive(false);
    }

    private void OnAttack() {
        if (isAttacking) return;
        StartCoroutine(PerformAttack());
    }
}
