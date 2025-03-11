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
    }
    void Start()
    {
        playerRadius = enemieStatesHandler.player.GetComponentInChildren<PlayerRadius>();        
    }
    public override void OnStateEnter()
    {
        movement.alreadyRoaming = true;
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

        else if (typeOfEnemy.tag == "MinionRat")
        {
            float distancesToTarget = Vector3.Distance(transform.position, playerRadius.gameObject.transform.position);

            if (distancesToTarget <= playerRadius.fearRadius)
            {
                if (fearState != null)
                    enemieStatesHandler.ChangeState(fearState);
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

    
    public void InfectMinion()
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
