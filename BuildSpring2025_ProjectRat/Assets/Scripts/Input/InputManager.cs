using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Input")]
    public InputAction movement;
    public InputAction interact;
    public InputAction attack;

    private PlayerControl playerControl;

    private void Awake() {
        playerControl = new PlayerControl();
    }

    public void EnableControls() {
        movement.Enable();
        interact.Enable();
        attack.Enable();
    }
    public void DisableControls() {
        movement.Disable();
        interact.Disable();
        attack.Disable();
    }

    private void OnEnable() {
        movement = playerControl.Player.Movement;
        interact = playerControl.Player.Interact;
        attack = playerControl.Player.Attack;

        EnableControls();
    }

    private void OnDisable() {
        DisableControls();
    }
}
