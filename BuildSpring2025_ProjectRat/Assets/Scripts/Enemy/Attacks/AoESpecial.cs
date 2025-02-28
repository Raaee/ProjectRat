using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoESpecial : MonoBehaviour
{
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float attackRadius = 5f;
    [SerializeField] private int attackDamage = 5;
    [SerializeField] private float delayPerSpawn = 0.2f;
    [SerializeField] private float damageDelay = 0.5f;
    public List<GameObject> collisions;

    public GameObject areaPrefab;
    public List<GameObject> spawnedAreas;

    [Header("SPAWN AREAS")]
    [SerializeField][Range(1, 10)] private int maxAmtPerAttack = 1;
    [SerializeField] private bool randomAmtPerAttack = true;

    private Vector2 randCenterPoint;

    [ProButton]
    private void Attack() {
        StartCoroutine(SpawnAreas());
    }
    private IEnumerator SpawnAreas() {
        int amtAreas = maxAmtPerAttack;
        collisions.Clear(); // resets lists of collisions
        RemoveOldAreas(); // clears old area game objects from scene

        if (randomAmtPerAttack) {
            amtAreas = Random.Range(1, maxAmtPerAttack);
        }
        int areaCounter = 0;
        while (areaCounter < amtAreas) {

            randCenterPoint = new Vector2(Random.Range(transform.position.x - spawnRadius, transform.position.x + spawnRadius),
            Random.Range(transform.position.y - spawnRadius, transform.position.y + spawnRadius)); // random point within a square area

            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(randCenterPoint, attackRadius);
            foreach (Collider2D hit in hitObjects) {
                collisions.Add(hit.gameObject);
            }
            GameObject areaGO = Instantiate(areaPrefab, randCenterPoint, Quaternion.identity);
            spawnedAreas.Add(areaGO);
            // spawning area should auto-start animations
            yield return new WaitForSeconds(delayPerSpawn);
            areaCounter++;
        }
        // trigger damage animations here
        yield return new WaitForSeconds(damageDelay);
        DamageAllCollisions();
    }
    private void DamageAllCollisions() {
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
    private void RemoveOldAreas() {
        foreach (GameObject go in spawnedAreas) {
            Destroy(go);
        }
        spawnedAreas.Clear();
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(randCenterPoint, attackRadius);
    }
}
