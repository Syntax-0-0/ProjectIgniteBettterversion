using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    private UIDocument document;

    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        document = GetComponent<UIDocument>();

        button = document.rootVisualElement.Q("StartGame") as Button;

        button.clicked += OnClick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick()
    {
        document.rootVisualElement.style.display = DisplayStyle.None;
        SceneManager.LoadScene("MainGameScene", LoadSceneMode.Single);
    }
}
