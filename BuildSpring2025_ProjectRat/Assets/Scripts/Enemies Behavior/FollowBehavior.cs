using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

public class FollowBehavior : MonoBehaviour
{
    [SerializeField] private StatesConditions statesConditions;
    [SerializeField] private GameObject objToMove;
    [SerializeField] private float enemySpeed = 2f;
    private ChasePlayerState chaseState;
    public bool isFollowing = false;
    public bool keepFollowingTarget = false;

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        chaseState = this.GetComponent<ChasePlayerState>();
    }

    private void Update()
    {
        if (isFollowing) {
            //MoveTowardsTarget(player.transform);
        }
    }

    [ProButton]
    public void StarFollowing()
    {
        //KeepFollowingTarget();
        isFollowing = true;
    }
    public void StopFollowingTarget()
    {
        isFollowing = false;
        //chaseState.StartRomingState();
    }

    public void StopFollowing()
    {
            //StartCoroutine(FollowForXSeconds());
    }

    public void KeepFollowingTarget()
    {
        isFollowing = true;
    }



}
