using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject objToMove;
    [SerializeField] private GameObject player;
    [SerializeField] private float enemySpeed = 2f;
    [SerializeField] private float secondsToFollow = 2f;


    public void MoveTowardsTarget(Transform targetTransform)
    {
        objToMove.transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, enemySpeed * Time.deltaTime);
    }
}
