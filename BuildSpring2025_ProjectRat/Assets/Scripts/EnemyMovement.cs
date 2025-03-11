using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject objToMove;
    [SerializeField] private RoamingState roaming;
    [SerializeField] private float enemySpeed = 2f;
    private GameObject player;
    private PlayerRadius playerRadius;
    private Vector2 targetPosition;
    public bool alreadyRoaming = false;
    public float roamRadius = 100f;

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


    public void MoveAwayFromTarget()
    {
        Debug.Log("MoveAwayFromTarget");
    }

    public void StartRoaming()
    {
        if (alreadyRoaming)
        {
            targetPosition = (Vector2)transform.position + Random.insideUnitCircle * roamRadius; // roaming behavior
            alreadyRoaming = false;
        }
        float distancesToTarget = Vector3.Distance(transform.position, playerRadius.gameObject.transform.position); 

        if (Vector2.Distance((Vector2)transform.position, targetPosition) > 0.1f && distancesToTarget >= playerRadius.aggroRadius) // if not close to target
        {
            MoveTowardsTarget(targetPosition);
        }

        else if (Vector2.Distance((Vector2)transform.position, targetPosition) <= 0.1f) // at the end of roam. find another point
        {
            targetPosition = (Vector2)transform.position + Random.insideUnitCircle * roamRadius;
        }
    }
}
