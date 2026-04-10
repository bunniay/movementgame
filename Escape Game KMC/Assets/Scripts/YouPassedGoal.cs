using UnityEngine;
using UnityEngine.SceneManagement;

public class YouPassedGoal : MonoBehaviour
{
    // A static variable keeps its value across all scene loads
    public static string sceneToLoadOnRetry;

    // This triggers when a 3D object enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the thing that hit us is the Player
        if (other.CompareTag("Player"))
        {
            TriggerGameOver();
        }
    }

    // The actual game over logic
    public void TriggerGameOver()
    {
        // Save the name of the CURRENT scene
        sceneToLoadOnRetry = SceneManager.GetActiveScene().name;

        // Load the Game Over scene 
        SceneManager.LoadScene("YouPassed");
    }
}