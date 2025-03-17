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
    }
    private void SpawnBoss(GameObject go)
    {
        Instantiate(Boss);
    }

}
