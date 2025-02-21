using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesConditions : MonoBehaviour
{
    private EnemieStates chaseState;
    private EnemieStates fearState;
    private EnemieStates attackState;
    private EnemieStates romingState;

    [SerializeField] private bool isBoss;
    private EnemieStatesHandler enemieStatesHandler;

    private void Start()
    {
        enemieStatesHandler = GetComponent<EnemieStatesHandler>();

        romingState = GetComponentInChildren<RomingState>();
        chaseState = GetComponentInChildren<ChaseState>();
        fearState = GetComponentInChildren<FearState>();
        attackState = GetComponentInChildren<AttackState>();
    }


    public void StartRomingState() {
        enemieStatesHandler.ChangeState(romingState);
    }
    public void StartChaseState() {
        enemieStatesHandler.ChangeState(chaseState);
    }
    public void StartFearState() {
        enemieStatesHandler.ChangeState(fearState);
    }
    public void StartAttackState() {
        enemieStatesHandler.ChangeState(attackState);
    }
}
