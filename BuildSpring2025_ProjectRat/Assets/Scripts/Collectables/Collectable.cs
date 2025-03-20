using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private bool delayDestroy = true;
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
=======
    [SerializeField] private bool instantKill = false;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Collect(collision.gameObject);
        } else if (collision.tag == "MinionRat") {
            MinionCollect(collision.gameObject);
        }

        if (instantKill) {
            DestroySelf();
        }
    }
    public abstract void Collect(GameObject collector);
    public abstract void MinionCollect(GameObject collector);
>>>>>>> main
    protected void DestroySelf() {
        Destroy(gameObject);
    }

}
