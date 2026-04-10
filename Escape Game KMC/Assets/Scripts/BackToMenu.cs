using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    //type menuname in inspector
    public string menuSceneName = "NewMainMenu";

    // call method on the events 
    public void ReturnToMenu()
    {
        // Loads the scene specified in the variable above
        SceneManager.LoadScene(menuSceneName);
    }
}