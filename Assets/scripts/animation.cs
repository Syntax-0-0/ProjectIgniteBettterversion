using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class animation : MonoBehaviour
{
    InputAction move;
    Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = move.ReadValue<Vector2>();
        this.transform.rotation = Quaternion.Euler(0,(Mathf.Atan2(moveDirection.x,moveDirection.y) * Mathf.Rad2Deg)+ 180,0);
    }
}
