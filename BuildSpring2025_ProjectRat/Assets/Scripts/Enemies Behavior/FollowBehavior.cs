using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

public class FollowBehavior : MonoBehaviour
{
    [SerializeField] private StatesConditions statesConditions;
    [SerializeField] private GameObject objToMove;
    [SerializeField] private GameObject player;
    [SerializeField] private float enemySpeed = 2f;
    [SerializeField] private float secondsToFollow = 2f;
    private ChaseState chaseState;
    public bool isFollowing = false;
    public bool keepFollowingTarget = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        chaseState = this.GetComponent<ChaseState>();
    }

    private void Update()
    {
        if (isFollowing) {
            MoveTowardsTarget(player.transform);
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
        chaseState.StartRomingState();
    }

    public void StopFollowing()
    {
        if (!keepFollowingTarget)
            StartCoroutine(FollowForXSeconds());
    }

    public void KeepFollowingTarget()
    {
        isFollowing = true;
    }


    public void MoveTowardsTarget(Transform targetTransform)
    {
        objToMove.transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, enemySpeed * Time.deltaTime);
    }

    public IEnumerator FollowForXSeconds()
    {
        yield return new WaitForSeconds(secondsToFollow);
        StopFollowingTarget();
    }
}
