using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
    [SerializeField] private EnemieStates attackState;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnStateEnter()
    {
        Debug.Log("The Enemy is chasing");
    }

    public override void OnStateExit()
    {

    }
    public override void OnFixedUpdate()
    {

    }


    public override void OnStateUpdate()
    {
        enemieStatesHandler.ChangeState(roamingState);
    }
}
