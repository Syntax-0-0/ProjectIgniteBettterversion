using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableSurface : MonoBehaviour
{
    InputAction interact;
    InputAction Exit;
    public GameObject mainCamera;
    public GameObject switchToCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
        Exit = InputSystem.actions.FindAction("Exit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        if (interact.IsPressed() && other.CompareTag("Player"))
        {
            mainCamera.SetActive(false);
            switchToCamera.SetActive(true);
            other.GetComponent<PlayerMovement>().movementSpeed = 0;
        }
        if (Exit.IsPressed() && other.CompareTag("Player"))
        {
            mainCamera.SetActive(true);
            switchToCamera.SetActive(false);
            other.GetComponent<PlayerMovement>().movementSpeed = 0.05f;
        }
    }
}
