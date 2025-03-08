using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Actions actions;
    private Collider2D attackCol;
    [SerializeField] private GameObject attackVisual;
    [SerializeField] public int attackDamage { get; set; } = 2;
    [SerializeField] private int poweredAttackDamage = 6;
    [SerializeField] private float attackDuration = 0.1f;
    public bool isAttacking { get; private set; }
    private AcidOrbs acidOrbs;

    [Header("DEBUG")]
    public bool spawnOrbs = true;

    [Header("TAGS")]
    private const string MINION_RAT_TAG = "MinionRat";
    private const string BOSS_TAG = "Boss";
    private const string BOSS_PODIUM_TAG = "BossPodium";

    private void Start() {
        acidOrbs = GetComponent<AcidOrbs>();
        attackCol = GetComponent<PolygonCollider2D>();
        actions = GetComponentInParent<Actions>();
        actions.OnAttack.AddListener(OnAttack);

        isAttacking = false;
        ToggleCollider();
    }
    private void OnAttack() {
        if (isAttacking) return;
        StartCoroutine(PerformAttack());
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
    private bool IsAcidOrbTriggered() {
        float chance = Random.Range(0, 1.0f);
        if (chance >= acidOrbs.spawnChance)
            return true;
        return false;
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (!isAttacking) return;

        if (col.gameObject.tag == MINION_RAT_TAG) {
     
        }
        if (col.gameObject.tag == BOSS_TAG) {
            if (spawnOrbs) TriggerOrbs();
            DamageBoss(col);
        }
        if (col.gameObject.tag == BOSS_PODIUM_TAG) {
        
        }
    }
    private void TriggerOrbs() {
        if (IsAcidOrbTriggered()) {
            acidOrbs.SpawnOrb();
        }
    }
    private void DamageBoss(Collider2D col) {
        int damage = attackDamage;
        if (acidOrbs.currentOrbs == acidOrbs.maxOrbs) {
            damage = poweredAttackDamage;
            acidOrbs.ResetOrbs();
        }
        col.gameObject.GetComponent<Health>().RemoveHealth(damage);
    }
}
