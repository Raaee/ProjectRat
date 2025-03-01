using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyCircle : AoEAttack 
{
    [SerializeField] private ParticleSystem ps;
    protected override void DebugLog() {
        Debug.Log("Holy Circle!");
    }

    protected override void StartAoEAnimation() {
        ps.Play();
    }
}
