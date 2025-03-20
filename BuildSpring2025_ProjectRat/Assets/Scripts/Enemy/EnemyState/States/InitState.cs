<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/InitState.cs
=======
using com.cyborgAssets.inspectorButtonPro;
>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/InitState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/InitState.cs
=======
    [SerializeField] private EnemieStates fearState;
    [SerializeField] private EnemieStates followState;
    [SerializeField] private EnemieStates chasePlayerState;
    [SerializeField] private float idleTime = 2f;
>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/InitState.cs

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnStateEnter()
    {
<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/InitState.cs
        enemieStatesHandler.ChangeState(roamingState);
=======
<<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/IdleState.cs
        StartCoroutine(WaitForXSeconds());
        Debug.Log("idling");
========
        enemieStatesHandler.ChangeState(roamingState);
>>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/InitState.cs
>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/InitState.cs
    }

    public override void OnStateExit()
    {

    }


    public override void OnStateUpdate()
    {

    }
    public override void OnFixedUpdate()
    {

    }
<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/InitState.cs
=======

    [ProButton]
    public void TestFollowPlayerForMinion()
    {
        if (followState != null)
            enemieStatesHandler.ChangeState(followState);
    }

    [ProButton]
    public void TestChasePlayerForBoss()
    {
        if (chasePlayerState != null)
            enemieStatesHandler.ChangeState(chasePlayerState);
    }

    public IEnumerator WaitForXSeconds() 
    {
        yield return new WaitForSeconds(idleTime);
        enemieStatesHandler.ChangeState(roamingState);
    }
>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/InitState.cs
}
