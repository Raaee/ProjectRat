using UnityEngine;
using UnityEngine.UI;

public class BossMainHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void Initialize(Health bossHealth, Color color)
    {
        slider = GetComponent<Slider>();

        bossHealth.OnHurt.AddListener(OnBossHurt);
        bossHealth.OnHeal.AddListener(OnBossHeal);
        bossHealth.OnDeath.AddListener(OnBossDeath);

        slider.maxValue = bossHealth.MaxHP;
        slider.value = bossHealth.CurrentHP;

        Transform fillArea = transform.Find("Fill Area");
        fillArea.gameObject.GetComponentInChildren<Image>().color = color;
    }

    private void OnBossHurt(float amt)
    {
        slider.value -= amt;
        Debug.Log("boss hurt!");
    }

    private void OnBossHeal(float amt)
    {
        slider.value += amt;
    }

    private void OnBossDeath(GameObject boss)
    {
        Destroy(gameObject);
    }
}

