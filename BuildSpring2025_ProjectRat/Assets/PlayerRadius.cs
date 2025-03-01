using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadius : MonoBehaviour
{
    [SerializeField] private List<EnemieStates> rats;
    [SerializeField] private List<EnemieStates> Bosses;
    //[SerializeField] private Transform currentPosition;
    public int fearRadius = 5;
    public int followRadius = 5;
    public int aggroRadius = 6;
    public int attackRadius = 2;
}
