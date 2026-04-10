using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    public string tutorialSceneName = "Stage1";

    public void StartStage1()
    {
        SceneManager.LoadScene(tutorialSceneName);
    }
}