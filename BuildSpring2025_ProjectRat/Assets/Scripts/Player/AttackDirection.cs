using UnityEngine;

public class AttackDirection : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private Transform attackTransform;
    private PlayerAttack playerAttack;
    private PlayerMovement playerMovement;

    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();

        Transform pivot = gameObject.transform.Find("Pivot");
        attackTransform = pivot.transform.Find("Attack");

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
