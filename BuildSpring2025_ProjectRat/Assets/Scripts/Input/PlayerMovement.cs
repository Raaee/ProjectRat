using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager inputManager;
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float smoothTime = 0.1f;
    public Vector2 moveDirection { get; set; } = Vector2.zero;
    private Vector2 currentVelocity = Vector2.zero;
    private Vector2 targetPos = Vector2.zero;
    
    void Awake() {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        moveDirection = inputManager.movement.ReadValue<Vector2>().normalized; // normalized movement direction taken from inputManager
        targetPos = Vector2.SmoothDamp(targetPos, moveDirection, ref currentVelocity, smoothTime); // smooths the movement

        rb.velocity = targetPos * moveSpeed;
    }
}
