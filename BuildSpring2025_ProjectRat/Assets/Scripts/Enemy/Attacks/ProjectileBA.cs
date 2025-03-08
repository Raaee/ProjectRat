using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBA : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float MaxlifeTime = 5f;

    private void Start()
    {
        
    }

    //creat the Projectile
    //Momment
    //Projectile Livetime


    //Throw Projectile
    //If hit player point
    //if end of live -> expode And creat a AoE

    private void SpanwPojectile(Vector2 moveDirection)
    {
        GameObject projectileGO = Instantiate(projectilePrefab, transform);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectile.SetMoveDirection(moveDirection);
        projectile.SetLifeTime(MaxlifeTime);
        // loop checking the condition of lifetime
        //spawns aoe at projectile pos
        // destroy proj
        //GOAoEAttk.StartAttack();
    }

    private void SpanwAoE(Transform pos)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpanwPojectile(collision.transform.position);
    }
}
