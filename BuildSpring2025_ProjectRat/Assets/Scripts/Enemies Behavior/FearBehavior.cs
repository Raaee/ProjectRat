using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearBehavior : MonoBehaviour
{
    [SerializeField] private StatesConditions statesConditions;


    //This is a test Script for the changing of states, This script does not need to be that final. 
    //This script will be use for the fear Be

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("The minio is Runing");
        statesConditions.StartFearState();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("The minio is Roming again ");
        statesConditions.StartRomingState();
    }

}
