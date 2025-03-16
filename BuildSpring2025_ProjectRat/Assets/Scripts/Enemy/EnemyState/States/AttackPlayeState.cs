using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayeState : EnemieStates
{
    [SerializeField] private EnemieStates chasePlayerState;
    [SerializeField] private PlayerRadius playerRadius;
    [SerializeField] private ProjectileBA projectileBA;
    [SerializeField] private PigeonSpecial pigeonSpecial;
    public bool specialUse = false;
    [SerializeField] private int secondsCooldown = 5;
    

    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        playerRadius = enemieStatesHandler.player.GetComponentInChildren<PlayerRadius>();        
    }

    public override void OnStateEnter()
    {
        Debug.Log("Attacking Player");

    }

    public override void OnStateExit()
    {
        projectileBA.secreteAttack = false;
    }

    public override void OnStateUpdate()
    {
        float distancesToTarget = Vector3.Distance(transform.position, playerRadius.transform.position);

        if (distancesToTarget >= playerRadius.attackRadius)
        {
            enemieStatesHandler.ChangeState(chasePlayerState);
        }
    }
    public override void OnFixedUpdate()
    {
        projectileBA.Attack();
        if (!projectileBA.isShooting)
        {
            projectileBA.Attack();
            projectileBA.isShooting = true;
        }

        if (transform.parent.parent.parent.GetComponent<Health>().CurrentHP == 100)
        {
            return;
        }

        if (transform.parent.parent.parent.GetComponent<Health>().CurrentHP % 25 == 0 && !specialUse)
        {
            pigeonSpecial.Attack();
            pigeonSpecial.Attack();
            specialUse = true;
            StartCoroutine(specialCoolDown());
        }
    }

    private IEnumerator specialCoolDown()
    {
        yield return new WaitForSeconds(secondsCooldown);
        specialUse = false;
    }
}
