using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
    [SerializeField] private EnemieStates fearState;
    [SerializeField] private EnemieStates followState;
    [SerializeField] private EnemieStates chasePlayerState;
    [SerializeField] private float idleTime = 2f;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnStateEnter()
    {
        StartCoroutine(WaitForXSeconds());
        Debug.Log("idling");
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
    public void TestFollowPlayerForMinion()
    {
        if (followState != null)
            enemieStatesHandler.ChangeState(followState);
    }

    [ProButton]
    public void TestChasePlayerForBoss()
    {
        if (chasePlayerState != null)
            enemieStatesHandler.ChangeState(chasePlayerState);
    }

    public IEnumerator WaitForXSeconds() 
    {
        yield return new WaitForSeconds(idleTime);
        enemieStatesHandler.ChangeState(roamingState);
    }
}
