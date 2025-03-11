using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieStatesHandler : MonoBehaviour
{
    [SerializeField] private EnemieStates startingState;
    [field: SerializeField] public EnemieStates CurrentState { get; set; }
    [SerializeField] public GameObject player;
    //Would it be better to add a references to the player in this Scrip
    //Or have every state have its own private reference to the player (reminder: Ask rea and pete)

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    private void Start()
    {
        CurrentState = startingState;
        CurrentState.OnStateEnter();
    }

    private void Update()
    {
        CurrentState.OnStateUpdate();
    }

    private void FixedUpdate()
    {
        CurrentState.OnFixedUpdate();
    }

    public void ChangeState(EnemieStates newState)
    {
        CurrentState.OnStateExit();
        CurrentState = newState;
        CurrentState.OnStateEnter();
    }
}