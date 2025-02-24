using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemieStates
{
    [SerializeField] private EnemieStates romingState;

    public override void Awake()
    {
        base.Awake();
    }

    private void FixedUpdate()
    {
        
    }

    public override void OnStateEnter()
    {
        Debug.Log("Enemy is currenly on Idle");
        enemieStatesHandler.ChangeState(romingState);
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateUpdate()
    {

    }
}
