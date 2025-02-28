using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadius : MonoBehaviour
{
    [SerializeField] private List<EnemieStates> rats;
    [SerializeField] private List<EnemieStates> Bosses;
    public bool IsObjectInRadius(EnemieStates obj) 
    {
        if (rats.Contains(obj))
            return true;
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            rats.Add(collision.gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<FearState>());
        }
        else if (collision.gameObject.tag == "Boss") 
        {
            Bosses.Add(collision.gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<ChasePlayerState>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            rats.Remove(collision.gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<FearState>());
        }
        else if (collision.gameObject.tag == "Boss")
        {
            Bosses.Remove(collision.gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<ChasePlayerState>());
        }
    }
}
