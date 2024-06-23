using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player Instance { get; private set; }
    public event EventHandler ShootPerformed;
    Vector2 rotation = Vector2.zero;
    [Range(0f, 1f), SerializeField] private float cameraSensitivity = 3;
    [SerializeField] private float playerSpeed;
    [SerializeField] Transform cameraTransform;
    [SerializeField] private Vector2 yAxisLimits;
    private Rigidbody rb;
    Vector2 mouseInputVector;
    Vector2 movementInputVector;
    private void Awake() {
        Instance = this;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start() {
        rb = GetComponent<Rigidbody>();
        GameInput.Instance.ShootPerformed += GameInput_ShootPerformed;
    }

    private void GameInput_ShootPerformed(object sender, EventArgs e) {
        Shoot();
    }

    private void Update() {
        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement() {
        movementInputVector = GameInput.Instance.GetMovementInput();
        Vector3 movement = new Vector3(movementInputVector.x, 0, movementInputVector.y);
        movement = playerSpeed * Time.deltaTime * movement.normalized;
        rb.velocity = cameraTransform.transform.TransformDirection(movement);
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.angularVelocity = Vector3.zero;
    }

    private void HandleRotation() {
        mouseInputVector = GameInput.Instance.GetMouseMovementInput();
        rotation.y += mouseInputVector.x;
        rotation.x += -1 * mouseInputVector.y;
        rotation.x = Mathf.Clamp(rotation.x, yAxisLimits.x, yAxisLimits.y);
        cameraTransform.transform.eulerAngles = rotation * cameraSensitivity;
    }
    private void Shoot() {
        ShootPerformed?.Invoke(this, EventArgs.Empty);
        Vector3 rayOrigin = cameraTransform.position;
        Vector3 rayDirection = cameraTransform.forward;
        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hit, Mathf.Infinity)) {
            if (hit.collider.gameObject.TryGetComponent(out Enemy enemy)) {
                enemy.Kill();
            }
            else if (hit.collider.gameObject.TryGetComponent(out Obstacle obstacle)) {
                obstacle.OnHit();
            }
        }

    }
}
