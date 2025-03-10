using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class EnemieStates : MonoBehaviour
{
    protected EnemieStatesHandler enemieStatesHandler;

    public virtual void Awake()
    {
        enemieStatesHandler = FindObjectOfType<EnemieStatesHandler>();
    }

    public abstract void OnStateEnter();
    public abstract void OnStateExit();
    public abstract void OnStateUpdate();

    public abstract void OnFixedUpdate();
}
