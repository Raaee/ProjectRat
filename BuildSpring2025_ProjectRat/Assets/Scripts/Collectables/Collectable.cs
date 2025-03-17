using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField] private bool delayDestroy = true;
    [SerializeField] protected float killDelay = 1f;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Collect(collision.gameObject);
        } else if (collision.tag == "MinionRat") {
            MinionCollect(collision.gameObject);
        }

        if (delayDestroy) {
            Delay();
        } else {
            DestroySelf();
        }
    }
    public abstract void Collect(GameObject collector);
    public abstract void MinionCollect(GameObject collector);
    protected abstract IEnumerator DelayedKill();
    protected void Delay() {
        StartCoroutine(DelayedKill());
    }
    protected void DestroySelf() {
        Destroy(gameObject);
    }

}
