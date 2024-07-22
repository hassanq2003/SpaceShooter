using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Make sure you have this if using UI components

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button startButton;

    private void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
        
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
    }

    private void ExitGame()
    {
        // Exit the application
        Application.Quit();
        
        #if UNITY_EDITOR
        // If running in the editor, stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private void StartGame()
    {
        // Load the scene at index 0
        SceneManager.LoadScene(1);
    }
}
