using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float smoothTime = 0.1f;

    private PlayerControl playerControl;
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 currentVelocity = Vector2.zero;
    private Vector2 targetPos = Vector2.zero;
    
    void Awake() {
        playerControl = new PlayerControl();
        rb = GetComponent<Rigidbody2D>();
        if (rb is null) {
            Debug.LogError("Rigidbody2D component is missing");
        }
    }

    private void OnEnable() {
        playerControl.Enable();
    }

    private void OnDisable() {
        playerControl.Disable();
    }

    void FixedUpdate() {
        moveDirection = playerControl.Player.Movement.ReadValue<Vector2>().normalized;
        targetPos = Vector2.SmoothDamp(targetPos, moveDirection, ref currentVelocity, smoothTime);

       rb.velocity = targetPos * moveSpeed;
    }
}
