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
    public bool isFollowing = false;
    public bool keepFollowingTarget = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

    [ProButton]
    public void StarFollowing()
    {
        statesConditions.StartChaseState();
        KeepFollowingTarget();
    }

    public void StopFollowing()
    {
        if (!keepFollowingTarget)
            StartCoroutine(FollowForXSeconds());
    }

    public void KeepFollowingTarget()
    {
        MoveTowardsTarget(player.transform);
        isFollowing = true;
    }

    public void StopFollowingTarget()
    {
        isFollowing = false;
    }

    public void MoveTowardsTarget(Transform targetTransform)
    {
        objToMove.transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, enemySpeed * Time.deltaTime);
    }

    public IEnumerator FollowForXSeconds()
    {
        yield return new WaitForSeconds(secondsToFollow);
        StopFollowingTarget();
        statesConditions.StartRomingState();
    }
}
