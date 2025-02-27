using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
    [SerializeField] private EnemieStates attackState;
    private FollowBehavior follow;
 
    public override void Awake()
    {
        base.Awake();
        follow = FindFirstObjectByType<FollowBehavior>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("The Enemy is chasing");
        //Addlisener.
    }

    public override void OnStateExit()
    {

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

    //StartFollow(){ follow.StartFollow(); }


}
