using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniousAI : MonoBehaviour
{
    [SerializeField] private StatesConditions statesConditions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        statesConditions.StartFearState();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        statesConditions.StartRomingState();
    }
}
