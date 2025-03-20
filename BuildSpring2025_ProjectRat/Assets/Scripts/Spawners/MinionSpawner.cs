using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
   // [SerializeField] private TextMeshProUGUI roamingCountText;
    [SerializeField] private GameObject rareRatPrefab;
    [SerializeField] private float rareRatSpawnChance = 0.0666f;
    public GameObject[] ratPrefabs; 
    [SerializeField] private GameObject centerTarget;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float spawnDelay = 0.5f;
    [SerializeField] private int maxSpawn = 50;
    public List<GameObject> spawnedMinions = new List<GameObject>();

    private bool isSpawning = false;
    private int roamingCount = 0;
    private int activeMinionCount = 0;    

    private void Start() 
    {
        isSpawning = true;
        StartSpawner();
       // UpdateRoamingCount();
    }   

    Vector2 MinionRadius() //establishes the radius around the target
    {
        Vector2 center = centerTarget.transform.position;

        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;
        return new Vector2(center.x + x, center.y + y);
    }
    public void MinionSpawn()
    {
        Vector2 spawnPos = MinionRadius();
        GameObject minion = Instantiate(GetRandomRat(), spawnPos, Quaternion.identity);
        spawnedMinions.Add(minion); // Add the spawned minion to the list
        roamingCount++;
        activeMinionCount++;
        //UpdateRoamingCount();
    }
    private GameObject GetRandomRat() {
        float ratChance = Random.Range(0f, 100f);
        if (ratChance <= rareRatSpawnChance) {
            return rareRatPrefab;
        }
        int randomRat = Random.Range(0, ratPrefabs.Length);
        return ratPrefabs[randomRat];
    }
    private IEnumerator MinionIntervals()
    {
        roamingCount = 0;

        while (isSpawning)
        {

            if (maxSpawn == -1 || roamingCount < maxSpawn) //logic for spawn count

            {
                MinionSpawn();
                yield return new WaitForSeconds(spawnDelay);
            }
            else
            {
                isSpawning = false;
                yield break;
            }
        }
    }
    //Debug Function
    [ProButton]
    private void StartSpawner()
    {
        isSpawning = true;
        StartCoroutine(MinionIntervals());
    }
    [ProButton]
    private void StopSpawner()
    {
        isSpawning = false;

    } 
  
    /*private void UpdateRoamingCount()
    {
        if (roamingCountText != null)
        {
            roamingCountText.text = $"Roaming count: {activeMinionCount}";
        }
    }*/
}