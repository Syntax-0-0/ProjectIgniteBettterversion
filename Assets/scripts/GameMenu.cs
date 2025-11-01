using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class GameMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private UIDocument document;
    private Button backToGame;
    private Button mainMenu;
    private Button quitGame;

    InputAction escape;
    void Start()
    {
        escape = InputSystem.actions.FindAction("mainMenu");

        document = GetComponent<UIDocument>();

        backToGame = document.rootVisualElement.Q("Continue") as Button;
        mainMenu = document.rootVisualElement.Q("MainMenu") as Button;
        quitGame = document.rootVisualElement.Q("QuitGame") as Button;

        quitGame.clicked += OnQuit;
        mainMenu.clicked += OnMainMenu;
        backToGame.clicked += OnContinue;

    }

    // Update is called once per frame
    void Update()
    {
        if (escape.WasPressedThisFrame())
        {
            OnContinue();
        }
    }

    private void OnContinue()
    {
        SceneManager.UnloadSceneAsync("GameMenu");
    }
    private void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }
    private void OnQuit()
    {
        Application.Quit();
    }
}
