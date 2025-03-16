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
    [SerializeField] private GameObject typeOfEnemy;
    private PlayerRadius playerRadius;

    public override void Awake()
    {
        base.Awake();
        playerRadius = enemieStatesHandler.player.GetComponentInChildren<PlayerRadius>();
    }

    public override void OnStateEnter()
    {
        StartCoroutine(WaitForXSeconds());
        
    }

    public override void OnStateExit()
    {
        
    }


    public override void OnStateUpdate()
    {
        if (typeOfEnemy.tag == "Boss")
        {
            float distancesToTarget = Vector3.Distance(transform.position, playerRadius.gameObject.transform.position);

            if (distancesToTarget <= playerRadius.aggroRadius)
            {
                if (chasePlayerState != null)
                    enemieStatesHandler.ChangeState(chasePlayerState);
            }
        }

        else if (typeOfEnemy.tag == "MinionRat")
        {
            float distancesToTarget = Vector3.Distance(transform.position, playerRadius.gameObject.transform.position);

            if (distancesToTarget <= playerRadius.fearRadius)
            {
                if (fearState != null)
                    enemieStatesHandler.ChangeState(fearState);
            }
        }
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
        float randomIdle = Random.Range(0.1f, 1.5f);
        Debug.Log(randomIdle);
        yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
        //pick a ramdom Idletime
        Debug.Log("idling");
        enemieStatesHandler.ChangeState(roamingState);
    }
}
