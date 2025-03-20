using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidOrb : Collectable
{
    [SerializeField] private Orb orbBehavior;

    private void Start() {
        orbBehavior.OnBehaviorComplete.AddListener(DestroySelf);
    }
    public override void Collect(GameObject collector) {
        collector.GetComponentInChildren<AcidOrbs>().AddOrbs(1);
        orbBehavior.DelayKill();
    }

    public override void MinionCollect(GameObject collector) {
        // do nothing
    }
}
