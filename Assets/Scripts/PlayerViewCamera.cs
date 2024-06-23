using UnityEngine;

/// <summary>
/// A simple FPP (First Person Perspective) camera rotation script.
/// Like those found in most FPS (First Person Shooter) games.
/// </summary>
public class PlayerViewCamera : MonoBehaviour {

    Vector2 rotation = Vector2.zero;
    [Range(0f, 1f), SerializeField] private float speed = 3;
    Vector2 inputVector;

    void Update() {
        inputVector = GameInput.Instance.GetMouseMovementInput();

        rotation.y += inputVector.x;
        rotation.x += -1 * inputVector.y;
        transform.eulerAngles = (Vector2)rotation * speed;
    }
}