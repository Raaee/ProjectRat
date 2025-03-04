using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

//main
public class MinionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject centerTargetPrefab;
    [SerializeField] private GameObject minionRatPrefab;
    [SerializeField] private TextMeshProUGUI roamingCountText;

    [SerializeField] private float radius = 5f;
    [SerializeField] private float spawnDelay = 0.5f;

    /*
        - Review:
        > add an int varaiable that determines the amount of minions that should spawn in the loop
        > if the number is -1, the loop will run infinitely
        > for example:
            if the number is a 9, it should spawn 9 minions and then the spawner should stop.

        - check reviews below
        - when complete, remove the review comments
    */

    private List<GameObject> spawnedMinions = new List<GameObject>(); // review: remove the clear minions, but keep this list. also make it public
    private Coroutine spawnCoroutine;
    private int roamingCount = 0;

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

        while (true)
        {
            MinionSpawn();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    /*private void Start() //commented for testing purposes
    {
        StartCoroutine(MinionIntervals());
    }*/


    //Debug Function
    [ProButton]
    private void StartSpawner()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(MinionIntervals());
            Debug.Log("Spawner Running");
        }
        else
        {
            Debug.Log("Error it can't Start");
        }

    }
    [ProButton]
    private void StopSpawner()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
            Debug.Log("Spawner done.");

            ClearMinions(); // review: minions should not be cleared. only the spawner should stop spawning.
        }
        else
        {
            Debug.LogWarning("Spawner can't run");
        }

    }
    // review: minions will be cleared somewhere else. this is not required. remove:
    private void ClearMinions() //Clears Minions after stopped
    {
        foreach (GameObject minion in spawnedMinions)
        {
            if (minion != null)
            {
                Destroy(minion);
            }
        }
        spawnedMinions.Clear();
        roamingCount = 0;
        UpdateRoamingCount();
        Debug.Log("All minions cleared.");
    }
    // review: add the canvas text to the scene: remember to save scene before committing
    private void UpdateRoamingCount()
    {
        if (roamingCountText != null)
        {
            roamingCountText.text = $"Roaming count: {roamingCount}";
        }
    }
}