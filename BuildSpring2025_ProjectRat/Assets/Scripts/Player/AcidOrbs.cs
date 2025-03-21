using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AcidOrbs : MonoBehaviour
{
    [SerializeField] private GameObject orbPrefab;
    [field: SerializeField] public float spawnChance { get; private set; } = 0.5f;
    [field: SerializeField] public int maxOrbs { get; private set; } = 10;
    [field: SerializeField] public int currentOrbs { get; private set; } = 0;
    private float spawnOffset = 5f;
    
    [HideInInspector] public UnityEvent OnOrbUpdate;

    private void Start() {
        ResetOrbs();
    }
    public void AddOrbs(int amt) {
        currentOrbs += amt;
        currentOrbs = Mathf.Clamp(currentOrbs, 0, maxOrbs);
        OnOrbUpdate.Invoke();
    }
    public void ResetOrbs() {
        currentOrbs = 0;
        OnOrbUpdate.Invoke();
    }
    public void SpawnOrb() {
        Vector3 position = new Vector3(Random.Range(transform.position.x - spawnOffset, transform.position.x + spawnOffset), 
            Random.Range(transform.position.y - spawnOffset, transform.position.y + spawnOffset), 0);
        Instantiate(orbPrefab, position, Quaternion.identity);
    }
}
