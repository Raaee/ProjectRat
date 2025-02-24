using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class RoamingState : EnemieStates
{
    [SerializeField] private EnemieStates chaseState;
    [SerializeField] private EnemieStates fearState;

    [SerializeField] private bool isBoss;

    public override void Awake()
    {
        base.Awake();
    }


    public override void OnStateEnter()
    {
        Debug.Log("Enemy is currenly on roaming");
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

    [ProButton]
    public void Roming()
    {
        if (isBoss)
            enemieStatesHandler.ChangeState(chaseState);
        else
            enemieStatesHandler.ChangeState(fearState);
    }
}
