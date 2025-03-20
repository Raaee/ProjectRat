using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesConditions : MonoBehaviour
{
    //Now redundant "Probally not going to used it"

    private EnemieStates chaseState;
    private EnemieStates fearState;
    private EnemieStates attackState;
    private EnemieStates roamingState;

    [SerializeField] private bool isBoss;
    private EnemieStatesHandler enemieStatesHandler;

    private void Start()
    {
        enemieStatesHandler = GetComponent<EnemieStatesHandler>();

        roamingState = GetComponentInChildren<RoamingState>();
        chaseState = GetComponentInChildren<ChasePlayerState>();
        fearState = GetComponentInChildren<FearState>();
        attackState = GetComponentInChildren<AttackPlayeState>();
    }


    public void StartRomingState() {
        enemieStatesHandler.ChangeState(roamingState);
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
