using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float smoothTime = 0.1f;
    public Vector2 moveDirection = Vector2.zero;

    private InputManager inputManager;
    private Rigidbody2D rb;
    private Vector2 currentVelocity = Vector2.zero;
    private Vector2 targetPos = Vector2.zero;
    
    void Awake() {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody2D>();
        if (rb is null) {
            Debug.LogError("Rigidbody2D component is missing");
        }
    }

    void FixedUpdate() {
        moveDirection = inputManager.movement.ReadValue<Vector2>().normalized;
        targetPos = Vector2.SmoothDamp(targetPos, moveDirection, ref currentVelocity, smoothTime);

       rb.velocity = targetPos * moveSpeed;
    }
}
