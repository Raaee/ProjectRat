using System.Collections.Generic;
using UnityEngine;

public class BossUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject bossHealthBar;
    [SerializeField] private GameObject bossHealthBarGroup;
    public List<BossPodium> podiums;

    private void Start()
    {
        ActivateBossListeners();
    }

    private void OnBossSpawn(GameObject boss, Color barColor)
    {
        GameObject newHealthBar = Instantiate(bossHealthBar, bossHealthBarGroup.transform);
        BossMainHealthBar barManager = newHealthBar.GetComponent<BossMainHealthBar>();

        Health bossHealth = boss.GetComponent<Health>();
        barManager.Initialize(bossHealth, barColor);
    }

    private void ActivateBossListeners()
    {
        foreach (var bossPodium in podiums)
        {
            bossPodium.OnBossSpawn.AddListener(OnBossSpawn);
        }
    }
}

