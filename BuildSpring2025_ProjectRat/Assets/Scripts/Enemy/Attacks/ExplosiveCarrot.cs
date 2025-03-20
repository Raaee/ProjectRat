using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCarrot : AoEAttack
{
    [SerializeField] private ParticleSystem ps;

    protected override void DebugLog() {
        Debug.Log("Explosive Carrot!");
    }
    protected override void StartAoEAnimation() {
        ps.Play();
    }
}
