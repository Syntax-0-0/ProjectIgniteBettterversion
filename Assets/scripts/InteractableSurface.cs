using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractableSurface : MonoBehaviour
{
    InputAction mousePos;
    InputAction interact;
    public GameObject interactText;
    public GameObject interactSurface;
    public Camera mainCamera;
    public float interactSize;
    public string switchToScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
        mousePos = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {

        if (interact.IsPressed())
        {
            Debug.Log("clicked");
            Vector2 location = mousePos.ReadValue<Vector2>();
            Vector3 location3 = new Vector3(location.x, location.y,0);
            Vector3 interactSurfacePos = mainCamera.WorldToScreenPoint(interactSurface.transform.position);
            interactSurfacePos.z = 0;
            if ((location3- interactSurfacePos).magnitude < interactSize)
            {
                SceneManager.LoadScene(switchToScene, LoadSceneMode.Single);
            }
            Debug.Log((location3- interactSurfacePos).magnitude);
            Debug.Log("interactSurface" + interactSurfacePos);
            Debug.Log("location3" + location3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("omgwow");
        if (other.CompareTag("Player"))
        {
            //Debug.Log(other);
            interactText.SetActive(true);
            interactSurface.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            //Debug.Log(other);
            interactText.SetActive(false);
            interactSurface.SetActive(false);
        }
    }
    public void OnInteract(InputAction input)
    {
        Debug.Log("clicked");
        Vector2 location = mousePos.ReadValue<Vector2>();
        Vector3 location3 = new Vector3 (location.x,0,location.y);
        Vector3 interactSurfacePos = mainCamera.WorldToScreenPoint(interactSurface.transform.position);
        interactSurfacePos.y = 0;
        if ((location3- interactSurfacePos).magnitude < interactSize)
        {
            SceneManager.LoadScene(switchToScene, LoadSceneMode.Single);
        }
    }
}
