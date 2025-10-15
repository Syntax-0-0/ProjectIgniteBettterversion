using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //assignable values
    public InputActionAsset inputActions;
    public CharacterController characterController;
    public float movementSpeed;

    InputAction move;
    InputAction walkPoint;

    Vector2 moveDirection;
    Vector2 movePoint;
    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    void Start()
    {
        move = InputSystem.actions.FindAction("Look");
        walkPoint = InputSystem.actions.FindAction("Interact");
    }
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        if (walkPoint.IsPressed())
        {
            movePoint = move.ReadValue<Vector2>();
        }
        Debug.Log(moveDirection);
    }
    private void FixedUpdate()
    {
        characterController.Move(new Vector3(movePoint.x, 0, movePoint.y).normalized * movementSpeed);
    }
}
