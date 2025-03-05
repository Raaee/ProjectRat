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
    [SerializeField] private PlayerRadius playerRadius;
    [SerializeField] private GameObject typeOfEnemy;
    //[SerializeField] private FollowCollision followCollision;
    //[SerializeField] private FearState fearStateGameObj;

    public override void Awake()
    {
        base.Awake();
        playerRadius = enemieStatesHandler.player.GetComponentInChildren<PlayerRadius>();
        //fearStateGameObj = this.transform.parent.GetComponentInChildren<FearState>();
    }


    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateUpdate()
    {
        /*if (typeOfEnemy.tag == "Minion")
        {
            float distancesToTarget = Vector3.Distance(transform.position, playerRadius.transform.position);

            if (distancesToTarget <= playerRadius.fearRadius)
            {
                if (followState != null)
                    enemieStatesHandler.ChangeState(followState);
            }

        }*/

        if (typeOfEnemy.tag == "Boss") 
        {
            float distancesToTarget = Vector3.Distance(transform.position, playerRadius.transform.position);

            if (distancesToTarget <= playerRadius.aggroRadius)
            {
                if (chasePlayerState != null)
                    enemieStatesHandler.ChangeState(chasePlayerState);
            }
        }

        movement.StartRoaming();
    }

        

    public override void OnFixedUpdate()
    {

        movement.StartRoaming();
    }


    public void StartFearState()
    {
        /*if (player.GetComponentInChildren<PlayerRadius>().IsObjectInRadius(fearStateGameObj))
        {
            enemieStatesHandler.ChangeState(fearState);
        }*/
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
