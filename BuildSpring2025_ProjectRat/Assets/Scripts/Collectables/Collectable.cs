using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
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
    protected void DestroySelf() {
        Destroy(gameObject);
    }

}
