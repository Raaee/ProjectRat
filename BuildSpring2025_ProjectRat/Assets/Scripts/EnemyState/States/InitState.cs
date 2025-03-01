using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnStateEnter()
    {
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
