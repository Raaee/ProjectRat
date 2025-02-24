using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class FearState : EnemieStates
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
        Debug.Log("The enemy is currenly in fear");
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {
        
    }

    [ProButton]
    public void Fear()
    {
        enemieStatesHandler.ChangeState(romingState);
    }
}
