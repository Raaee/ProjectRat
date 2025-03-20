using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

public class ChaseBossState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
    [SerializeField] private EnemieStates attackBossState;
    [SerializeField] private EnemieStates followState;
    [SerializeField] private EnemyMovement movement;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {
        //Get CurrentBoss that the player has attack
        //movement.MoveTowardsTarget(CurrentBoss);
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
