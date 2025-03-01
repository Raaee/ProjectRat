using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

public class ChasePlayerState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
    [SerializeField] private EnemieStates attackPlayerState;
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private float secondsToFollow = 2f;
    [SerializeField] private PlayerRadius playerRadius;
    [SerializeField] private int aggroTimer = 3;
    //[SerializeField] private FollowCollision followCollision;
    //private FollowBehavior follow;

    public override void Awake()
    {
        base.Awake();
        //player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        // follow = FindFirstObjectByType<FollowBehavior>();
        playerRadius = enemieStatesHandler.player.GetComponentInChildren<PlayerRadius>();
    }

    public override void OnStateEnter()
    {
        //followCollision.OnExitRadius.AddListener(StartRomingState);
    }

    public override void OnStateExit()
    {

    }
    public override void OnFixedUpdate()
    {
        
    }

    public override void OnStateUpdate()
    {
        float distancesToTarget = Vector3.Distance(transform.position, playerRadius.transform.position);
        if (distancesToTarget >= playerRadius.aggroRadius)
        {
            playerIsOutOfAggroRange();
        }

        if (distancesToTarget <= playerRadius.attackRadius)
        {
            enemieStatesHandler.ChangeState(attackPlayerState);
        }

        movement.MoveTowardsTarget(enemieStatesHandler.player.transform);
    }

    [ProButton]
    public void playerIsOutOfAggroRange() 
    {
        StartCoroutine(ChaseForXSeconds());
    }

    public IEnumerator ChaseForXSeconds()
    {
        yield return new WaitForSeconds(secondsToFollow);
        enemieStatesHandler.ChangeState(roamingState);
    }

}

