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
    [SerializeField] private GameObject MiniBar;
    [SerializeField] private ParticleSystem podiumParticleSystem;

    [Header("Podium Requirements")]
    [SerializeField] private int bossesBeatenRequirement = 0;
    public static int bossesBeaten;
    [HideInInspector] private bool isActive = false;
    void Start()
    {
        podiumParticleSystem = GetComponentInChildren<ParticleSystem>();
        podiumCollider = GetComponent<CapsuleCollider2D>();
        health = GetComponent<Health>();
        health.OnDeath.AddListener(SpawnBoss);
    }

    private void Update()
    {
        if (!isActive && bossesBeaten >= bossesBeatenRequirement)
        {
            isActive = true;
            Debug.Log("Podium " + gameObject.name + " activated");
            podiumCollider.enabled = true;
            MiniBar.SetActive(true);
            podiumParticleSystem.Play();
        }
    }

    private void SpawnBoss(GameObject _)
    {
        MiniBar.SetActive(false);

        podiumCollider.enabled = false;
        GameObject newBoss = Instantiate(Boss);

        OnBossSpawn.Invoke(newBoss, GetBossColor());
        newBoss.GetComponent<Health>().OnDeath.AddListener(OnBossDeath);

        StartCoroutine(DestroySelf());
    }

    private void OnBossDeath(GameObject go)
    {
        bossesBeaten++;
        Destroy(gameObject);
    }

    public Color GetBossColor()
    {
        return Boss.GetComponentInChildren<SpriteRenderer>().sharedMaterial.GetColor("_Outline_Color");
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(destroySeconds);
        gameObject.SetActive(false);
    }
}
