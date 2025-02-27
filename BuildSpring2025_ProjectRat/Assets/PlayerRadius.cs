using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadius : MonoBehaviour
{
    [SerializeField] private List<FearState> rats;
    public bool IsObjectInRadius(FearState obj) 
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            rats.Remove(collision.gameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<FearState>());
        }
    }
}
