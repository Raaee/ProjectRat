using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float smoothTime = 0.1f;

    private PlayerControl _playerControl;
    private Rigidbody2D _rb;
    private Vector2 _moveDirection = Vector2.zero;
    private Vector2 _currentVelocity = Vector2.zero;
    private Vector2 _targetPos = Vector2.zero;
    
    void Awake() {
        _playerControl = new PlayerControl();
        _rb = GetComponent<Rigidbody2D>();
        if (_rb is null) {
            Debug.LogError("Rigidbody2D component is missing");
        }
    }

    private void OnEnable() {
        _playerControl.Enable();
    }

    private void OnDisable() {
        _playerControl.Disable();
    }

    void FixedUpdate() {
        _moveDirection = _playerControl.Player.Movement.ReadValue<Vector2>().normalized;
        _targetPos = Vector2.SmoothDamp(_targetPos, _moveDirection, ref _currentVelocity, smoothTime);

        _rb.velocity = _targetPos * moveSpeed;
    }
}
