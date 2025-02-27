using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCollision : MonoBehaviour
{
    [SerializeField] private FollowBehavior followBehavior;
    //Add Event OnCollision


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //OnCollision.Invoke
        followBehavior.StarFollowing();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        followBehavior.StopFollowing();
    }
}
