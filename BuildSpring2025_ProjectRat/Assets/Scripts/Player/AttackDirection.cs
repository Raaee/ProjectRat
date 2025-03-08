using UnityEngine;

public class AttackDirection : MonoBehaviour
{
    private PlayerAttack playerAttack;
    private PlayerMovement playerMovement;

    [SerializeField] private Transform attackTransform;
    [SerializeField] private Transform attackPivot;
    private Vector2 direction;

    private void Awake() {
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        direction = Vector2.right;
    }

    private void FixedUpdate() {
        Vector2 latestDirection = playerMovement.moveDirection;
        bool isDiagonal = latestDirection.x != 0 && latestDirection.y != 0,
            isMoving = latestDirection != Vector2.zero;

        if (isMoving && !isDiagonal) {
            direction = latestDirection;
        }

        if (playerAttack.isAttacking) {
            return;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        attackTransform.rotation = Quaternion.Euler(0, 0, angle);
        attackTransform.localPosition = direction;
    }
}
