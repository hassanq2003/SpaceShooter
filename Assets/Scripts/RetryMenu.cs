using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Make sure you have this if using UI components

public class RetryMenu : MonoBehaviour
{
    [SerializeField] private Button MainMenu;
    [SerializeField] private Button Retry;

    private void Start()
    {
        if (MainMenu != null)
        {
            MainMenu.onClick.AddListener(mainMenu);
        }
        
        if (Retry != null)
        {
            Retry.onClick.AddListener(StartGame);
        }
    }

    private void mainMenu()
    {
            SceneManager.LoadScene(0);
    }

    private void StartGame()
    {
        // Load the scene at index 0
        SceneManager.LoadScene(1);
    }
}
