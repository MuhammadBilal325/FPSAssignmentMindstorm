using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour {
    public static GameInput Instance { get; private set; }
    public event EventHandler ShootPerformed;
    private PlayerInputActions playerInputActions;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.ShootInput.performed += ShootInput_performed;
        playerInputActions.Player.Enable();
    }

    private void ShootInput_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        ShootPerformed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMouseMovementInput() {
        return playerInputActions.Player.MouseLook.ReadValue<Vector2>();
    }
    public Vector2 GetMovementInput() {
        return playerInputActions.Player.Movement.ReadValue<Vector2>();
    }

}
