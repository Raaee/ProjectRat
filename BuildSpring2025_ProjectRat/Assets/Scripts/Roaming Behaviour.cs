using System.Collections;
using TMPro;
using UnityEngine;

public class RoamingBehaviour : MonoBehaviour
{
    
    public float roamRadius = 10f;             // var which modifies roam radius
    [SerializeField] private float speed = 4f; // var which modifies roam speed
    private Vector2 targetPosition;  

    void Start()
    {
        StartCoroutine(Roam());
    }

    IEnumerator Roam()
    {
        while(true)
        {
            targetPosition = (Vector2)transform.position + Random.insideUnitCircle * roamRadius;

            while (Vector2.Distance((Vector2)transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
