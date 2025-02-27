using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class RoamingState : EnemieStates
{
    [SerializeField] private EnemieStates chaseState;
    [SerializeField] private EnemieStates fearState;
    [SerializeField] private GameObject player;
    [SerializeField] private FollowCollision followCollision;
    [SerializeField] private FearState fearStateGameObj;

    public override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        fearStateGameObj = this.transform.parent.GetComponentInChildren<FearState>();
    }


    public override void OnStateEnter()
    {
        Debug.Log("Enemy is currenly on roaming");
        followCollision.OnRadius.AddListener(StartChaseState);
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateUpdate()
    {
        Debug.Log(player.GetComponentInChildren<PlayerRadius>());
        if (player.GetComponentInChildren<PlayerRadius>().IsObjectInRadius(fearStateGameObj))
        {
            StartFearState();
        }
    }

    public override void OnFixedUpdate()
    {
        
        //PlayerRadius.(Player.IsObjectInRadius(this)
    }

    public void StartChaseState()
    {
        enemieStatesHandler.ChangeState(chaseState);
    }

    public void StartFearState()
    {
        enemieStatesHandler.ChangeState(fearState);
    }
}
