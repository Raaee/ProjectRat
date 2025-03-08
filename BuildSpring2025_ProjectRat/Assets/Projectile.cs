using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : AoEAttack
{
    [SerializeField] private float projectileSpeed = 5f;
    private float lifeTime = 5f;
    [SerializeField] private int ProjectileDamage = 1;
    private Vector2 moveDirection;
    private float timer = 0f; // Timer used to track the lifetime of the projectile.
    private Rigidbody2D rb2D;

    [HideInInspector] public UnityEvent OnProjecDisabled;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveProjectile();

        timer += Time.deltaTime;

        // If the projectile has existed for longer than its maximum lifetime, disable it
        if (timer >= lifeTime)
        {
            DisableProjectile();
            timer = 0;
        }
    }

    public void MoveProjectile()
    {
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(transform.rotation.eulerAngles.z, angle, projectileSpeed * Time.deltaTime));
        rb2D.velocity = moveDirection * projectileSpeed * Time.fixedDeltaTime;
    }

    public void SetMoveDirection(Vector2 movDir)
    {
        //this.isPlayerShooting = isPlayerShooting;
        moveDirection = movDir;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Payer")
        {
            Health playerHealth = collider.gameObject.GetComponent<Health>();
            playerHealth.RemoveHealth(ProjectileDamage);
        }
    }

        private void DisableProjectile()
    {
        //OnProjectileDisabled?.Invoke();
        OnProjecDisabled?.Invoke();
        Destroy(this.gameObject);
    }
    public void SetLifeTime(float life)
    {
        lifeTime = life;
    }



    protected override void DebugLog()
    {
        throw new System.NotImplementedException();
    }

    protected override void StartAoEAnimation()
    {
        throw new System.NotImplementedException();
    }
}
