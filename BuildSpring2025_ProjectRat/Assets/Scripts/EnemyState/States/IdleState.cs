using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnStateEnter()
    {
        Debug.Log("Enemy is currenly on Idle");
        enemieStatesHandler.ChangeState(roamingState);
    }

    public override void OnStateExit()
    {
        
    }


    public override void OnStateUpdate()
    {

    }
    public override void OnFixedUpdate()
    {

    }
}
