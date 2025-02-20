using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieStatesHandler : MonoBehaviour
{
    [SerializeField] private EnemieStates startingState;
    [field: SerializeField] public EnemieStates CurrentState { get; set; }

    private void Start()
    {
        CurrentState = startingState;
        CurrentState.OnStateEnter();
    }

    private void Update()
    {
        CurrentState.OnStateUpdate();
    }

    public void ChangeState(EnemieStates newState)
    {
        CurrentState.OnStateExit();
        CurrentState = newState;
        CurrentState.OnStateEnter();
    }
}