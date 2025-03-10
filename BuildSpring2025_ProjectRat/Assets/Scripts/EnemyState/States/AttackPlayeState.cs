using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayeState : EnemieStates
{
    [SerializeField] private EnemieStates chasePlayerState;
    [SerializeField] private PlayerRadius playerRadius;
    [SerializeField] private ProjectileBA projectileBA;
    

    public override void Awake()
    {
        base.Awake();
        playerRadius = enemieStatesHandler.player.GetComponentInChildren<PlayerRadius>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("Attacking Player");

    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {
        float distancesToTarget = Vector3.Distance(transform.position, playerRadius.transform.position);

        if (distancesToTarget >= playerRadius.attackRadius)
        {
            enemieStatesHandler.ChangeState(chasePlayerState);
        }
    }
    public override void OnFixedUpdate()
    {
        if (!projectileBA.isShooting)
        {
            projectileBA.Attack();
            projectileBA.isShooting = true;
        }
    }
}
