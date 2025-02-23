using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//main
public class MinionSpawner : MonoBehaviour
{
    public GameObject ratKingPrefab;
    public GameObject minionRatPrefab;
    public float radius;
  
    Vector2 MinionRadius() //establishes the radius around the king
    {
        Vector2 center = ratKingPrefab.transform.position;

        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;
        return new Vector2(center.x + x, center.y + y);
    }
    public void MinionSpawn()
    {
        Vector2 spawnPos = MinionRadius();
        Instantiate(minionRatPrefab, spawnPos, Quaternion.identity);
    }
    private IEnumerator MinionIntervals() //Courintine timer for spawner
    {
        
        while (true)
        {
            MinionSpawn();
            yield return new WaitForSeconds(0.5f);
        }
    }

        void Start()
    {
            StartCoroutine(MinionIntervals());

    }
}

