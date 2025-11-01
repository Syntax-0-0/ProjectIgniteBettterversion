using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoadMenuScript : MonoBehaviour
{
    InputAction menuOpen;
    bool menuIsOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuOpen = InputSystem.actions.FindAction("mainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (menuOpen.WasPressedThisFrame() && (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenuScene") && SceneManager.GetSceneByName("GameMenu").isLoaded != true))
        {
            SceneManager.LoadScene("GameMenu", LoadSceneMode.Additive);
        }
    }
}
