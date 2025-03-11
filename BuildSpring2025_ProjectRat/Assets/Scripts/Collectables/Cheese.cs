using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Collectable
{
    [SerializeField] private int healAmount = 10;
    public override void Collect(GameObject collector)
    {
        FindObjectOfType<Health>().AddHealth(healAmount);
    }

    public override void MinionCollect(GameObject collector)
    {
        throw new System.NotImplementedException();
    }

    protected override IEnumerator DelayedKill()
    {
        yield return new WaitForSeconds(0.2f);
        DestroySelf();
    }
}
