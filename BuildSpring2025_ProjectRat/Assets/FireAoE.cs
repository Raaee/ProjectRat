using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAoE : AoEAttack
{
    public void StartAoE(Projectile projectile)
    {
        /*//Debug.Log(projectile.randCenterPoint + "End Position");
        projectile.randCenterPoint = projectile.transform.position;
        StartAttack();*/
    }

    protected override void DebugLog()
    {
        //throw new System.NotImplementedException();
    }

    protected override void StartAoEAnimation()
    {
        //throw new System.NotImplementedException();
    }
}
