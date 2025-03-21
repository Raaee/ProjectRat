using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
    [SerializeField] private EnemieStates attackBossState;
    [SerializeField] private EnemieStates chaseBossState;
    [SerializeField] private EnemyMovement movement;
    private PlayerRadius playerRadius;
    //[SerializeField] private FollowCollision followCollision;
    //private FollowBehavior follow;
    //public bool keepFollowingTarget = false;

    public override void Awake()
    {
        base.Awake();
        playerRadius = enemieStatesHandler.player.GetComponentInChildren<PlayerRadius>();
        //player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {
        float distancesToTarget = Vector3.Distance(transform.position, playerRadius.transform.position);
        if (distancesToTarget < playerRadius.followRadius)
        {
            movement.isFearing = true;
            movement.MoveAwayFromTarget();
            return;
        }
        if(distancesToTarget <= playerRadius.followRadius)
        {
            return;
        }

        movement.isFearing = false;
        movement.FollowingTarget(enemieStatesHandler.player.transform.position);
    }

    public override void OnFixedUpdate()
    {

    }

    [ProButton]
    public void MinionPurification()
    {
        Debug.Log("purified minion");
        enemieStatesHandler.ChangeState(roamingState);
    }
}
