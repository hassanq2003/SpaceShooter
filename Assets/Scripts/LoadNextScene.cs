using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private GameObject playerObject; // Reference to the player object
    

    void Update()
    {
        // Check if the player object is null
        if (playerObject == null)
        {
            // Start the coroutine to load the scene after a delay
            Invoke("LoadSceneAfterDelay",0.5f);
        }
    }

    private void LoadSceneAfterDelay()
    {

        // Load scene 2
        SceneManager.LoadScene(2);
    }
}
