using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    void Start()
    {
        //Unlock the cursor so it can move freely
        Cursor.lockState = CursorLockMode.None;

        // Make the cursor visible again
        Cursor.visible = true;
    }
    // Call this method from your UI Button's OnClick event
    public void OnRetryClicked()
    {
        // Check to make sure the string isn't empty
        if (!string.IsNullOrEmpty(GameOverTrigger.sceneToLoadOnRetry))
        {
            // Load the scene we saved right before dying
            SceneManager.LoadScene(GameOverTrigger.sceneToLoadOnRetry);
        }
        else
        {
            // Fallback: If you test the Game Over scene directly from the editor, 
            // the static variable will be empty. This loads your first level as a backup.
            Debug.LogWarning("No previous scene found. Loading Stage 1 as fallback.");
            SceneManager.LoadScene(1);
        }
    }

}