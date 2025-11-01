using UnityEngine;
using UnityEngine.InputSystem;

public class cuttingHand : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject knifeHand;
    public GameObject normalHand;
    public GameObject grabHand;
    public GameObject Knife;

    private bool knifeMode;
    InputAction handMove;
    InputAction interact;
    InputAction exit;

    Vector2 handPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handMove = InputSystem.actions.FindAction("Look");
        interact = InputSystem.actions.FindAction("Interact");
        exit = InputSystem.actions.FindAction("Exit");
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
        moveHand();
        if (!knifeMode)
        {
            if (interact.WasPressedThisFrame())
            {
                grabMechanic();
            }

            if (interact.WasReleasedThisFrame())
            {
                normalHand.SetActive(true);
                grabHand.SetActive(false);
            }
        }
        else
        {
            if (interact.WasPressedThisFrame())
            {
                cut();
            }
            if (exit.WasPressedThisFrame())
            {
                placeBackKnife();
            }
        }

    }

    public void KnifeMode()
    {
        normalHand.SetActive(false);
        knifeHand.SetActive(true);
        Knife.SetActive(false);
        knifeMode = true;
    }

    public void grabMechanic()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log(hit);
            Debug.Log(hit.transform.gameObject.tag);
            switch (hit.transform.gameObject.tag)
            {
                case "Knife":
                    KnifeMode();
                    break;

                case "fruit":
                    normalHand.SetActive(false);
                    grabHand.SetActive(true);
                    break;

                default:
                    break;
            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("No object to grab");
        }
    }

    public void cut()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            if (hit.transform.gameObject.CompareTag("fruit"))
            {
                hit.transform.gameObject.GetComponent<fruitinteraction>().CutMeIAmAFruit();
            }
            
        }
    }

    public void placeBackKnife()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            if (hit.transform.gameObject.CompareTag("holster"))
            {
                normalHand.SetActive(true);
                knifeHand.SetActive(false);
                Knife.SetActive(true);
                knifeMode = false;
            }

        }
    }

    public void moveHand()
    {
        handPos = handMove.ReadValue<Vector2>();
        Vector3 pos = mainCamera.ScreenToWorldPoint(handPos);
        pos.y = 3.15f;
        this.transform.position = pos;
    }
}
