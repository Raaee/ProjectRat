using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Collectable
{
    [SerializeField] private Orb orbBehavior;
    [SerializeField] private int healAmount = 10;

    private void Start() {
        orbBehavior.OnBehaviorComplete.AddListener(DestroySelf);
    }
    public override void Collect(GameObject collector)
    {
        FindObjectOfType<Health>().AddHealth(healAmount);
        orbBehavior.DelayKill();
    }

    public override void MinionCollect(GameObject collector)
    {
        // do nothing
    }
}
