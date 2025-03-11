using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class FearState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
    [SerializeField] private PlayerRadius playerRadius;
    [SerializeField] private EnemyMovement movement;
    

    public override void Awake()
    {
        base.Awake();
        playerRadius = enemieStatesHandler.player.GetComponentInChildren<PlayerRadius>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("The enemy is currenly in fear");
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {

        float distancesToTarget = Vector3.Distance(transform.position, playerRadius.transform.position);
        if (distancesToTarget >= playerRadius.fearRadius)
        {
            enemieStatesHandler.ChangeState(roamingState);
        }

        if (!movement.isFearing)
        {
            movement.MoveAwayFromTarget();
        }
        else
        {
            movement.isFearing = false;
        }
    }
    public override void OnFixedUpdate()
    {

    }
}
