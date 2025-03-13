using System.Collections;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField] private bool delayDestroy = true;
    private int despawnDurationSeconds = 60;
    private Coroutine despawnTimer;

    private void Start() {
        despawnTimer = StartCoroutine(OutOfBoundsTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Collect(collision.gameObject);
        } else if (collision.tag == "MinionRat") {
            MinionCollect(collision.gameObject);
        }

        if (collision.tag == "Player" || collision.tag == "MinionRat") {
            if (delayDestroy) {
                Delay();
            } else {
                DestroySelf();
            }
        }

        if (collision.tag == "MainCamera") {
            StopCoroutine(despawnTimer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "MainCamera") {
            despawnTimer = StartCoroutine(OutOfBoundsTimer());
        }
    }

    private IEnumerator OutOfBoundsTimer() {
        yield return new WaitForSeconds(despawnDurationSeconds);

        DestroySelf();
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
