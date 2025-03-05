using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//main
public class MinionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject centerTargetPrefab;
    [SerializeField] private GameObject minionRatPrefab;
    [SerializeField] private TextMeshProUGUI roamingCountText;

    [SerializeField] private float radius = 5f;
    [SerializeField] private float spawnDelay = 0.5f;
    [SerializeField] private int spawnMax = 50;
    [SerializeField] private bool isSpawning = false;
    


    public List<GameObject> spawnedMinions = new List<GameObject>(); 


    private int roamingCount = 0;

    private void Start() 
    {
        StartSpawner();
    }
   

    Vector2 MinionRadius() //establishes the radius around the target
    {
        Vector2 center = centerTargetPrefab.transform.position;

        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;
        return new Vector2(center.x + x, center.y + y);
    }
    public void MinionSpawn()
    {
        Vector2 spawnPos = MinionRadius();
        GameObject minion = Instantiate(minionRatPrefab, spawnPos, Quaternion.identity);
        spawnedMinions.Add(minion); // Add the spawned minion to the list
        roamingCount++;
        UpdateRoamingCount();
    }
    private IEnumerator MinionIntervals() //Courintine timer for spawner
    {
        while (isSpawning)
        {

            if (spawnMax == -1 || roamingCount < spawnMax) //logic for spawn count

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
  
    private void UpdateRoamingCount()
    {
        if (roamingCountText != null)
        {
            roamingCountText.text = $"Roaming count: {roamingCount}";
        }
    }
}