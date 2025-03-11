using System.Collections;
using UnityEngine;

public class MouseTrap : Collectable
{
    [SerializeField] private int playerDmg = 10;
    protected override IEnumerator DelayedKill()
    {
        yield return new WaitForSeconds(2);
        DestroySelf();
    }

    public override void Collect(GameObject player)
    {
        player.GetComponent<Health>().RemoveHealth(playerDmg);
    }

    public override void MinionCollect(GameObject minionRat)
    {
        Debug.Log("Rats purify!");
    }
}
