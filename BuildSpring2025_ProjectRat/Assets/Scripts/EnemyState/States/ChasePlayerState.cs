using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
    [SerializeField] private EnemieStates attackPlayerState;
    [SerializeField] private FollowCollision followCollision;
    private FollowBehavior follow;

    public override void Awake()
    {
        base.Awake();
        follow = FindFirstObjectByType<FollowBehavior>();
    }

    public override void OnStateEnter()
    {
        StartFollow();
        followCollision.OnExitRadius.AddListener(StartRomingState);
    }

    public override void OnStateExit()
    {
        StopFollow();
    }
    public override void OnFixedUpdate()
    {
        
    }

    public override void OnStateUpdate()
    {
        if (follow.isFollowing)
        {
            follow.KeepFollowingTarget();
        }
        else
        {
            follow.StopFollowingTarget();
        }
    }

    public void StartRomingState()
    {
        enemieStatesHandler.ChangeState(roamingState);
    }

    private void StartFollow()
    { 
        follow.StarFollowing(); 
    }

    private void StopFollow() 
    {
        follow.StopFollowing();
    }
}
