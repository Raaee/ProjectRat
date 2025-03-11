using UnityEngine;
using System.Collections;

public class MouseTrapSpawner : MonoBehaviour
{
    public int minTimerRangeSeconds = 5;
    public int maxTimerRangeSeconds = 10;

    [SerializeField] private int timerDuration;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject mouseTrap;
    private Coroutine timer;
    private void Awake() {
        player.GetComponent<Health>().OnDead.AddListener(StopTimer);
        
        timer = StartCoroutine(Timer());
    }

    private IEnumerator Timer() {
        yield return new WaitForSeconds(timerDuration);

        int isVertical = Random.Range(0,2);


        int boundary = Random.Range(0,2);
        float randomLoc = Random.Range(0f,101f) / 100f;

        float[] offset = { -0.1f, 0.1f };
        Vector3 pos;
        if (isVertical == 1) {
            pos = mainCamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(randomLoc, boundary + offset[boundary], 0));
        } else {
            pos = mainCamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(boundary + offset[boundary], randomLoc , 0));
        }
        pos.z = 0f;

        Instantiate(mouseTrap, pos, Quaternion.identity);

        timer = StartCoroutine(Timer());
    }

    private void StopTimer() {
        Debug.Log("Stopping Mouse Trap timer, player is dead :(");
        StopCoroutine(timer);
    }
}
