using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FollowCollision : MonoBehaviour
{
    [SerializeField] private FollowBehavior followBehavior;
    public UnityEvent OnRadius;
    public UnityEvent OnExitRadius;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnRadius?.Invoke();
        //OnCollision.Invoke
        //followBehavior.StarFollowing();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnExitRadius?.Invoke();
        //followBehavior.StopFollowing();
    }
}
