using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Collectable
{
<<<<<<< HEAD
    [SerializeField] private int healAmount = 10;
    public override void Collect()
    {
        FindObjectOfType<Health>().AddHealth(healAmount);
    }
    protected override IEnumerator DelayedKill()
    {
        yield return new WaitForSeconds(0.2f);
        DestroySelf();
=======
    [SerializeField] private Orb orbBehavior;
    [SerializeField] private int healAmount = 10;

    private void Start() {
        orbBehavior.OnBehaviorComplete.AddListener(DestroySelf);
    }
    public override void Collect(GameObject collector)
    {
        collector.GetComponent<Health>().AddHealth(healAmount);
        orbBehavior.DelayKill();
    }

    public override void MinionCollect(GameObject collector)
    {
        // do nothing
>>>>>>> main
    }
}
