using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//main
public class CheeseSpawn : MonoBehaviour
{
    [SerializeField] private GameObject centerTarget;
    [SerializeField] private GameObject CheesePrefab;
    [SerializeField] private float radius = 20f;
    [SerializeField] private float spawnDelay = 10f;
    [SerializeField] private bool isSpawning = true;
   
    void Start()
    {
        StartCoroutine(CheeseIntervals());
    }

    Vector2 CheeseRadius() // Player radius
    {
        Vector2 center = centerTarget.transform.position;
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;
        return new Vector2(center.x + x, center.y + y);

    }

    //Cheese Instaniation
    public void SpawnCheese() 
    {
        Vector2 spawnPos = CheeseRadius();
        GameObject cheese = Instantiate(CheesePrefab, spawnPos, Quaternion.identity);
    }
    //Courintine timer
    private IEnumerator CheeseIntervals()
    {
        while (isSpawning)
        {

            SpawnCheese();
            yield return new WaitForSeconds(spawnDelay);
        }

    }
    [ProButton]
    private void SpawnerStart()
    {
        isSpawning = true;
        StartCoroutine(CheeseIntervals());
    }
    [ProButton]
    private void StopSpawner()
    {
        isSpawning = false;
    }

    //

}
