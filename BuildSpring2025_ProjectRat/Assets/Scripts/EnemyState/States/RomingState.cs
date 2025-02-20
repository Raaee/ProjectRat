using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class RomingState : EnemieStates
{
    [SerializeField] private EnemieStates chaseState;
    [SerializeField] private EnemieStates fearState;

    [SerializeField] private bool isBoss;

    public override void OnStateEnter()
    {
        Debug.Log("Enemy is currenly on Roming");
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateUpdate()
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
