using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Actions actions;
    private Collider2D attackCol;
    [SerializeField] private GameObject attackVisual;
    [SerializeField] private int attackDamage = 2;
    [SerializeField] private float attackDuration = 0.1f;
    public bool isAttacking { get; private set; }

    [Header("TAGS")]
    private const string MINION_RAT_TAG = "MinionRat";
    private const string BOSS_TAG = "Boss";
    private const string BOSS_PODIUM_TAG = "BossPodium";

    private void Start() {
        attackCol = GetComponent<PolygonCollider2D>();
        actions = GetComponentInParent<Actions>();
        actions.OnAttack.AddListener(OnAttack);

        isAttacking = false;
        ToggleCollider();
    }
    private IEnumerator PerformAttack() {
        isAttacking = true;
        ToggleCollider();
        yield return new WaitForSeconds(attackDuration);

        isAttacking = false;
        ToggleCollider();
    }
    private void ToggleCollider() {
        attackCol.enabled = isAttacking;
        attackVisual.SetActive(isAttacking);
    }
    private void OnAttack() {
        if (isAttacking) return;
        StartCoroutine(PerformAttack());
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (!isAttacking) return;

        if (col.gameObject.tag == MINION_RAT_TAG) {
     
        }
        if (col.gameObject.tag == BOSS_TAG) {
            col.gameObject.GetComponent<Health>().RemoveHealth(attackDamage);
        }
        if (col.gameObject.tag == BOSS_PODIUM_TAG) {
        
        }
    }
}
