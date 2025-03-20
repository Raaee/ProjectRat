using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

public class ChaseBossState : EnemieStates
{
    [SerializeField] private EnemieStates roamingState;
<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/ChaseBossState.cs
    [SerializeField] private EnemieStates attackBossState;
    [SerializeField] private EnemieStates followState;
=======
<<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/FearState.cs
    [SerializeField] private PlayerRadius playerRadius;
========
    [SerializeField] private EnemieStates attackBossState;
    [SerializeField] private EnemieStates followState;
>>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/ChaseBossState.cs
>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/ChaseBossState.cs
    [SerializeField] private EnemyMovement movement;

    public override void Awake()
    {
        base.Awake();
<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/ChaseBossState.cs
=======
        playerRadius = enemieStatesHandler.player.GetComponentInChildren<PlayerRadius>();
>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/ChaseBossState.cs
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {
<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/ChaseBossState.cs
        //Get CurrentBoss that the player has attack
        //movement.MoveTowardsTarget(CurrentBoss);
=======
<<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/FearState.cs

        float distancesToTarget = Vector3.Distance(transform.position, playerRadius.transform.position);
        if (distancesToTarget >= playerRadius.fearRadius)
        {
            enemieStatesHandler.ChangeState(roamingState);
        }

        movement.MoveAwayFromTarget();
========
        //Get CurrentBoss that the player has attack
        //movement.MoveTowardsTarget(CurrentBoss);
>>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/ChaseBossState.cs
>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/ChaseBossState.cs
    }

    public override void OnFixedUpdate()
    {

    }
<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/ChaseBossState.cs
=======
<<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/FearState.cs
========
>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/ChaseBossState.cs

    [ProButton]
    public void TestMinionPurified()
    {
        enemieStatesHandler.ChangeState(roamingState);
    }
<<<<<<< HEAD:BuildSpring2025_ProjectRat/Assets/Scripts/EnemyState/States/ChaseBossState.cs
=======
>>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/ChaseBossState.cs
>>>>>>> spriteSlices:BuildSpring2025_ProjectRat/Assets/Scripts/Enemy/EnemyState/States/ChaseBossState.cs
}
