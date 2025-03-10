using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private int ProjectileDamage = 1;
    private Vector3 moveDirection;
    public float lifeTime = 5f;
    private float timer = 0f; // Timer used to track the lifetime of the projectile.
    private Rigidbody2D rb2D;

    [HideInInspector] public UnityEvent<Projectile> OnProjecDisabled;


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
            //randCenterPoint = transform.position
            DisableProjectile();
            timer = 0;
        }

    }

    public void MoveProjectile()
    {
        rb2D.velocity = new Vector2(moveDirection.x, moveDirection.y).normalized * projectileSpeed;
        float angle = Mathf.Atan2(-moveDirection.y, -moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        //rb2D.AddForce(moveDirection * projectileSpeed * Time.fixedDeltaTime);
    }

    public void SetMoveDirection(Vector3 movDir)
    {
        moveDirection = movDir - transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Health playerHealth = collider.gameObject.GetComponent<Health>();
            playerHealth.RemoveHealth(ProjectileDamage);
            Debug.Log("Player Hit"); 
        }
    }

    public void DisableProjectile()
    {
        //randCenterPoint = transform.position;
        OnProjecDisabled?.Invoke(this);
        Destroy(this.gameObject);
    }

    public void SetLifeTime(float life)
    {
        lifeTime = life;
    }
}
