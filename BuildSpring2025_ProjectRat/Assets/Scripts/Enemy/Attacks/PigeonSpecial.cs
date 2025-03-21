using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonSpecial : AoESpecial
{
    [field: SerializeField] public float spawnRadius { get; private set; } = 10f;
    [SerializeField] private float delayPerSpawn = 0.2f;
    public GameObject attackPrefab;

    [Header("SPAWN AREAS")]
    [SerializeField] [Range(1, 50)] private int maxAmtPerAttack = 1;
    [SerializeField] private bool randomAmtPerAttack = true;

    private Vector2 randCenterPoint;
    [ProButton]
    public void Attack()
    {
        StartCoroutine(SpawnAreas());
    }
    private IEnumerator SpawnAreas()
    {
        int amtAreas = maxAmtPerAttack;

        if (randomAmtPerAttack)
        {
            amtAreas = Random.Range(1, maxAmtPerAttack);
        }

        int areaCounter = 0;
        while (areaCounter < amtAreas)
        {

            randCenterPoint = new Vector2(Random.Range(transform.position.x - spawnRadius, transform.position.x + spawnRadius),
            Random.Range(transform.position.y - spawnRadius, transform.position.y + spawnRadius)); // random point within a square area

            GameObject areaGO = Instantiate(attackPrefab, randCenterPoint, Quaternion.identity);
            AoEAttack attack = areaGO.GetComponent<AoEAttack>();
            attack.spawnRadius = spawnRadius;
            attack.randCenterPoint = randCenterPoint;
            attack.StartAttack();

            yield return new WaitForSeconds(delayPerSpawn);
            areaCounter++;
        }
    }
}
