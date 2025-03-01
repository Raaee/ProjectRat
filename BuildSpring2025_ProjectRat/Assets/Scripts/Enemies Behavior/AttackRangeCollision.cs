using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeCollision : MonoBehaviour
{
    [SerializeField] private FollowBehavior followBehavior;
    [SerializeField] private AttackBehavior attackBehavior;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //followBehavior.StopFollowingTarget();
        //attackBehavior.StarAttack();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //followBehavior.StarFollowing();
    }
}
