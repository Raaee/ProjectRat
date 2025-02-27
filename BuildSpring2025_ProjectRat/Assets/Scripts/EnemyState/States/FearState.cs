using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class FearState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;

    //Change to chaseState

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnStateEnter()
    {
        Debug.Log("The enemy is currenly in fear");
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

    public void StartRomingState()
    {
        enemieStatesHandler.ChangeState(roamingState);
    }
}
