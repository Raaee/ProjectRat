using UnityEngine;

public class AttackDirection : MonoBehaviour
{
    [SerializeField] private Vector2 direction = Vector2.zero;
    [SerializeField] private GameObject attackGameObject; 
    private PlayerAttack playerAttack;
    private PlayerMovement playerMovement;

    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        attackGameObject = GameObject.Find("Attack");
    }

    private void FixedUpdate() {
        if (playerAttack.isAttacking) {
            return;
        }        

        // Preserve latest travelled direction
        Vector2 latestDirection = playerMovement.moveDirection;
        if (latestDirection.x != 0 || latestDirection.y != 0) { 
            direction = latestDirection;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        attackGameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        attackGameObject.transform.localPosition = direction;
    }
}
