using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AoEAttack : MonoBehaviour
{
    [SerializeField] private float attackRadius = 5f;
    [SerializeField] private int attackDamage = 5;
    [SerializeField] private float damageDelay = 0.5f;
    [SerializeField] private float despawnDelay = 1f;
    public float spawnRadius { get; set; } = 10f;
    public Vector2 randCenterPoint { get; set; } = Vector2.zero;
    
    public List<GameObject> collisions;

    protected abstract void DebugLog();
    public virtual void StartAttack() {
        DebugLog();
        StartCoroutine(DetectCollisions());
    }
    protected abstract void StartAoEAnimation();
    private IEnumerator DetectCollisions() {
        yield return new WaitForSeconds(damageDelay);
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(randCenterPoint, attackRadius);
        foreach (Collider2D hit in hitObjects) {
            collisions.Add(hit.gameObject);
        }
        StartAoEAnimation();
        DamageAllCollisions();
        yield return new WaitForSeconds(despawnDelay);
        DestroySelf();
    }
    protected void DamageAllCollisions() {
        foreach (GameObject go in collisions) {
            if (go.tag == "Player") {
                go.GetComponent<Health>().RemoveHealth(attackDamage);
            }
            if (go.tag == "MinionRat") {
                //go.GetComponent<AggroStatus>().isAggro = false; // this where the purification happens
                Debug.Log("Purified", gameObject);
            }
        }
    }
    private void DestroySelf() {
        Destroy(gameObject);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(randCenterPoint, attackRadius);
    }
}
