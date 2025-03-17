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
        FindObjectOfType<AcidOrbs>().AddOrbs(1);
        orbBehavior.DelayKill();
    }

    public override void MinionCollect(GameObject collector) {
        // do nothing
    }

    protected override IEnumerator DelayedKill() {
        yield return new WaitForSeconds(killDelay);
        DestroySelf();
    }
}
