using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BossPodium : MonoBehaviour
{
    [HideInInspector] public UnityEvent<GameObject, Color> OnBossSpawn;
    private Health health;
    private CapsuleCollider2D podiumCollider;
    [SerializeField] private int destroySeconds = 2;
    [SerializeField] private GameObject Boss;

    void Start()
    {
        podiumCollider = GetComponent<CapsuleCollider2D>();
        health = GetComponent<Health>();
        health.OnDeath.AddListener(SpawnBoss);
    }

    private void SpawnBoss(GameObject go)
    {
        podiumCollider.enabled = false;
        GameObject newBoss = Instantiate(Boss);

        OnBossSpawn.Invoke(newBoss, GetBossColor());

        StartCoroutine(DestroySelf());
    }

    public Color GetBossColor()
    {
        return Boss.GetComponentInChildren<SpriteRenderer>().sharedMaterial.GetColor("_Outline_Color");
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(destroySeconds);
        Destroy(gameObject);
    }
}
