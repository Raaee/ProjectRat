using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBA : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject fireAoE;
    [SerializeField] private float MaxlifeTime = 5f;
    private PlayerRadius playerRadius;
    public float lifeTime = 5f;
    public bool isShooting = false;
    [SerializeField] private int secondsIntervals = 2;
    [SerializeField]public bool secreteAttack = false;

    private void Start()
    {
        playerRadius = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerRadius>();
    }

    public void Attack()
    {
        SpanwPojectile(GameObject.FindGameObjectWithTag("Player").transform.position);
    }


    private void FixedUpdate()
    {
        
    }

    public void SpanwPojectile(Vector2 moveDirection)
    {
        Debug.Log(moveDirection);
        if (isShooting)
        {
            return;
        }

        GameObject projectileGO = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectile.SetMoveDirection(moveDirection);
        projectile.SetLifeTime(MaxlifeTime);
        projectile.OnProjecDisabled.AddListener(StartAoE);
    }

    public void StartAoE(Projectile projectile)
    {
        if (secreteAttack)
        {
            isShooting = false;
        }
        //isShooting = false;
        GameObject AoEEffect = Instantiate(fireAoE, projectile.transform.position, Quaternion.identity);
        AoEAttack attack = AoEEffect.GetComponent<AoEAttack>();
        attack.StartAttack();
        StartCoroutine(attackIntervals());
        /*rojectile.randCenterPoint = projectile.transform.position;
        projectile.StartAttack();*/
    }

    private IEnumerator attackIntervals()
    {
        yield return new WaitForSeconds(secondsIntervals);
        isShooting = false;
        //SpanwPojectile(GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
