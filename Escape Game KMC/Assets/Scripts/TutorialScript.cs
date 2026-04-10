using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    public string tutorialSceneName = "Tutorial";

    public void StartTutorial()
    {
        SceneManager.LoadScene(tutorialSceneName);
    }
}