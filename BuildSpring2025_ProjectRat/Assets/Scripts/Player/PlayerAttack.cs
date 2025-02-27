using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Actions actions;
    private Collider2D attackCol;
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private float attackDuration = 0.1f;
    public bool isAttacking { get; private set; }

    [Header("TAGS")]
    private const string MINION_RAT_TAG = "MinionRat";
    private const string BOSS_TAG = "Boss";
    private const string BOSS_PODIUM_TAG = "BossPodium";

    private void Start() {
        attackCol = attackCollider.GetComponent<PolygonCollider2D>();
        actions = GetComponentInParent<Actions>();
        actions.OnAttack.AddListener(OnAttack);
        attackCollider.SetActive(false);
    }
    private IEnumerator PerformAttack() {
        isAttacking = true;
        attackCollider.SetActive(isAttacking);
        attackCol.enabled = isAttacking;
        yield return new WaitForSeconds(attackDuration);

        isAttacking = false;
        attackCol.enabled = isAttacking;
        attackCollider.SetActive(isAttacking);
    }
    private void OnAttack() {
        if (isAttacking) return;
        StartCoroutine(PerformAttack());
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!isAttacking) return;
        
        if (collision.tag == MINION_RAT_TAG) {
     
        }
        else if (collision.tag == BOSS_TAG) {
        
        }
        else if (collision.tag == BOSS_PODIUM_TAG) {
        
        }
    }
}
