using UnityEngine;
using UnityEngine.InputSystem;

public class cuttingHand : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject knifeHand;
    public GameObject normalHand;
    public GameObject grabHand;

    InputAction handMove;
    InputAction interact;

    Vector2 handPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handMove = InputSystem.actions.FindAction("Look");
        interact = InputSystem.actions.FindAction("Interact");
    }
    private void Awake()
    {
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (interact.WasPressedThisFrame())
        {
            grabMechanic();
        }

        handPos = handMove.ReadValue<Vector2>();
        Vector3 pos = mainCamera.ScreenToWorldPoint(handPos);
        pos.y = 3.15f;
        this.transform.position = pos;

        if (interact.WasReleasedThisFrame())
        {
            normalHand.SetActive(true);
            grabHand.SetActive(false);
        }
    }

    public void KnifeMode()
    {
        
    }

    public void grabMechanic()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            normalHand.SetActive(false);
            grabHand.SetActive(true);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log(hit);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
