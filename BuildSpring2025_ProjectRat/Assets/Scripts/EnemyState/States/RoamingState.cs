using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class RoamingState : EnemieStates
{
    [SerializeField] private EnemieStates followState;
    [SerializeField] private EnemieStates fearState;
    [SerializeField] private EnemieStates idleState;
    [SerializeField] private EnemieStates chasePlayerState;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private GameObject typeOfEnemy;
    private PlayerRadius playerRadius;

    public override void Awake()
    {
        base.Awake();
        playerRadius = enemieStatesHandler.player.GetComponentInChildren<PlayerRadius>();
    }

    public override void OnStateEnter()
    {
        movement.firstTarget = true;
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {
        if (typeOfEnemy.tag == "Boss") 
        {
            float distancesToTarget = Vector3.Distance(transform.position, playerRadius.gameObject.transform.position);

            if (distancesToTarget <= playerRadius.aggroRadius)
            {
                if (chasePlayerState != null)
                    enemieStatesHandler.ChangeState(chasePlayerState);
            }
        }
    }

        
    public override void OnFixedUpdate()
    {
        movement.StartRoaming();
    }

    public virtual void ToIdle()
    {
        enemieStatesHandler.ChangeState(idleState);
    }

    [ProButton]
    public void TestFollowPlayerForMinion()
    {
        if (followState != null)
            enemieStatesHandler.ChangeState(followState);
    }

    [ProButton]
    public void TestChasePlayerForBoss()
    {
        if (chasePlayerState != null)
            enemieStatesHandler.ChangeState(chasePlayerState);
    }

    
}
