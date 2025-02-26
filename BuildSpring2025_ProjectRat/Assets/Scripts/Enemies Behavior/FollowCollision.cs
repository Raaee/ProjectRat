using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCollision : MonoBehaviour
{
    [SerializeField] private FollowBehavior followBehavior;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        followBehavior.StarFollowing();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        followBehavior.StopFollowing();
    }
}
