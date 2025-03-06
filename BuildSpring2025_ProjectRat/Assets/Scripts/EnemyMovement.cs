using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject objToMove;
    [SerializeField] private GameObject player;
    [SerializeField] private float enemySpeed = 2f;
    [SerializeField] private float secondsToFollow = 2f;
    public bool isRoaming = false;
    [SerializeField] private RoamingState roaming;

    public float targetVector;
    public float roamRadius = 100f;     

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
        
    }

    
}
