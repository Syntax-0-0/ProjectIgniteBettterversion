using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class animation : MonoBehaviour
{
    public CharacterController characterController;
    InputAction move;
    public Animator animator;
    //Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //move = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("walkSpeed", characterController.velocity.magnitude);
        // moveDirection = move.ReadValue<Vector2>();
        if (characterController.velocity.magnitude > 0.9f)
        {
            animator.SetBool("Walking", true);
            this.transform.rotation = Quaternion.Euler(0, (Mathf.Atan2(characterController.velocity.x, characterController.velocity.z) * Mathf.Rad2Deg)+ 180, 0);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }
}
