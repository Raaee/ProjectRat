using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPodium : MonoBehaviour
{
    private Health health;
    [SerializeField] private GameObject Boss;

   
    void Start()
    {
        health = GetComponent<Health>();

        health.OnDeath.AddListener(SpawnBoss);
        Debug.Log("Lisenting for health");
    }
    private void SpawnBoss(GameObject go)
    {
        Instantiate(Boss);
        Debug.Log("Death");
    }

}
