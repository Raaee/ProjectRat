using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject objToMove;
    [SerializeField] private RoamingState roaming;
    [SerializeField] private float enemySpeed = 2f;
    [SerializeField] private float roamingSpeed = 5f;
    [SerializeField] private float followingSpeed = 5f;
    [SerializeField] private float fearSpeed = 5f;
    public bool isFearing { get; set; } = false;
    private GameObject player;
    private PlayerRadius playerRadius;
    public Vector2 targetPosition { get; set; }
    public bool alreadyRoaming = false;
    public float roamRadius = 100f;

    public UnityEvent OnTargetPosition;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        playerRadius = player.GetComponentInChildren<PlayerRadius>();
    }

    public void MoveTowardsTarget(Transform targetTransform)
    {
        objToMove.transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, enemySpeed * Time.deltaTime);
    }

    public void MoveTowardsTarget(Vector2 targetposition)
    {
        objToMove.transform.position = Vector2.MoveTowards(transform.position, targetposition, enemySpeed * Time.deltaTime);
    }

    public void FollowingTarget(Vector2 targetposition)
    {
        enemySpeed = followingSpeed;
        MoveTowardsTarget(targetposition);
    }

    public void MoveAwayFromTarget()
    {
        if (!isFearing)
        {
            return;
        }
        enemySpeed = 0;
        enemySpeed = fearSpeed;
        Debug.Log("MoveAwayFromTarget");
        MoveTowardsTarget(transform.position - player.transform.position);
    }

    public void StartRoaming()
    {
        enemySpeed = roamingSpeed;
        if (alreadyRoaming)
        {
            targetPosition = (Vector2)transform.position + Random.insideUnitCircle * roamRadius; // roaming behavior
            alreadyRoaming = false;
        }

        float distancesToTarget = Vector3.Distance(transform.position, playerRadius.gameObject.transform.position);
        float distFromRoamPos = Vector2.Distance((Vector2)transform.position, targetPosition);


        if (distancesToTarget >= playerRadius.fearRadius)
        {
            MoveTowardsTarget(targetPosition);
        }

        if (distFromRoamPos > 0.1f && distancesToTarget >= playerRadius.aggroRadius) // if not close to target
        {
            MoveTowardsTarget(targetPosition);
        }

        else if (Vector2.Distance((Vector2)transform.position, targetPosition) <= 0.1f) // at the end of roam. find another point
        {
            targetPosition = (Vector2)transform.position + Random.insideUnitCircle * roamRadius;
            OnTargetPosition?.Invoke();
        }
    }
}
