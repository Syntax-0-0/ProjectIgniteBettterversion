using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //assignable values
    public InputActionAsset inputActions;
    public CharacterController characterController;
    public float movementSpeed;
    public Camera mainCamera;

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
        if (walkPoint.IsPressed())
        {
            movePoint = move.ReadValue<Vector2>();
        }
        //Debug.Log(moveDirection);

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(movePoint.x, movePoint.y, 0));
        //characterController.transform.position = new Vector3(mousePosition.x,1,mousePosition.z);
        if ((mousePosition-characterController.transform.position).magnitude > 1f)
        {
            Vector3 moveDirection = new Vector3((mousePosition-characterController.transform.position).x, 0, (mousePosition-characterController.transform.position).z);
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);
            characterController.Move((moveDirection * movementSpeed) * Time.deltaTime);
        }
        //Debug.Log(mousePosition);
    }
    private void FixedUpdate()
    {

    }
}
