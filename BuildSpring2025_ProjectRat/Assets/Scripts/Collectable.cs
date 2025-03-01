using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public abstract void Collect();
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Collect();
            Destroy(gameObject);
        }
    }
}
