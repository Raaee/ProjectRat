using System.Collections;
using UnityEngine;

public class MouseTrap : Collectable
{
    [SerializeField] private int playerDmg = 10;
    public override void Collect(GameObject player)
    {
        player.GetComponent<Health>().RemoveHealth(playerDmg);
    }

    public override void MinionCollect(GameObject minionRat)
    {
        Debug.Log("Rats purify!");
    }
}
