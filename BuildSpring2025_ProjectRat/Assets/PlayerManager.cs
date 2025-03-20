using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private List<GameObject> Bosses;
    [SerializeField] int healthIncreaseValue = 10;
    [SerializeField] int attackIncreaseValue = 10;
    //[SerializeField] int healthIncressValue = 10;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    private void Start()
    {
        if(Bosses.Count < 1)
        {
            return;
        }

        //player.GetComponent<Health>().OnDeath.AddListener(IncreasePlayerStats);
        foreach(var boss in Bosses)
        {
            boss.GetComponent<Health>().OnDeath.AddListener(IncreasePlayerStats);
        }
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Boss") && !Bosses.Contains(GameObject.FindGameObjectWithTag("Boss")))
        {
            Bosses.Add(GameObject.FindGameObjectWithTag("Boss"));
        }
    }

    private void IncreasePlayerStats(GameObject boss)
    {
        player.GetComponent<Health>().MaxHP = player.GetComponent<Health>().MaxHP + healthIncreaseValue;
        player.GetComponentInChildren<PlayerAttack>().attackDamage = player.GetComponentInChildren<PlayerAttack>().attackDamage + attackIncreaseValue;
        Bosses.Remove(boss);
    }
}
