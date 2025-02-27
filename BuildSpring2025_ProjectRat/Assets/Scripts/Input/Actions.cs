using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Actions : MonoBehaviour {

    private InputManager inputManager;
    [HideInInspector] public UnityEvent OnInteract;    
    [HideInInspector] public UnityEvent OnAttack;

    private void Awake() {
        inputManager = GetComponent<InputManager>();
    }

    private void Update() {
        inputManager.interact.performed += Interact;
        inputManager.attack.performed += Attack;
    }

    public void Interact(InputAction.CallbackContext context) {
        Debug.Log("Interact");
        OnInteract.Invoke();
    }

    public void Attack(InputAction.CallbackContext context) {
        Debug.Log("Attack");
        OnAttack.Invoke();
    }
}
