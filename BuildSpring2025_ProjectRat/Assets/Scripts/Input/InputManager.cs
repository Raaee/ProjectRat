using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControl playerControl;

    [HideInInspector] public InputAction movement;
    [HideInInspector] public InputAction interact;
    [HideInInspector] public InputAction attack;

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
