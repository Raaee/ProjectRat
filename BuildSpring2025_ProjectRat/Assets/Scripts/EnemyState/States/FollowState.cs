using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
    [SerializeField] private EnemieStates attackBoss;
    [SerializeField] private EnemieStates chaseBoss;
    [SerializeField] private FollowCollision followCollision;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private GameObject player;
    private FollowBehavior follow;
    public bool keepFollowingTarget = false;

    public override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {
        movement.MoveTowardsTarget(player.transform);
    }

    public override void OnFixedUpdate()
    {

    }

    [ProButton]
    public void TestMinionPurified()
    {
        enemieStatesHandler.ChangeState(roamingState);
    }
}
