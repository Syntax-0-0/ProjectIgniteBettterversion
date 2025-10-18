using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class animation : MonoBehaviour
{
    public CharacterController characterController;
    InputAction move;
    //Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //move = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {

        // moveDirection = move.ReadValue<Vector2>();
        if (characterController.velocity.magnitude > 0.9f)
        {
            this.transform.rotation = Quaternion.Euler(0, (Mathf.Atan2(characterController.velocity.x, characterController.velocity.z) * Mathf.Rad2Deg)+ 180, 0);
        }
    }
}
