using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : MonoBehaviour
{
    [SerializeField] private StatesConditions statesConditions;
    [SerializeField] private float enemySpeed = 2f;
    //[SerializeField] private float enemySmoothRotation = 5f;
    //[SerializeField] private GameObject objToRotate;
    [SerializeField] private GameObject objToMove;
    public bool StopFolloing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        statesConditions.StartChaseState();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        statesConditions.StartRomingState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopFolloing = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StopFolloing = true;
    }

    public void MoveTowardsTarget(Transform targetTransform)
    {
        objToMove.transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, enemySpeed * Time.deltaTime);
    }
}
