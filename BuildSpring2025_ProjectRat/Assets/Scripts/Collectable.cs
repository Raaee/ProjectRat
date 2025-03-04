using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField] private bool delayDestroy = false;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Collect();
            if (delayDestroy) {
                Delay();
            } else {
                DestroySelf();
            }
        }
    }
    public abstract void Collect();
    protected abstract IEnumerator DelayedKill();
    protected void Delay() {
        StartCoroutine(DelayedKill());
    }
    protected void DestroySelf() {
        Destroy(gameObject);
    }

}
