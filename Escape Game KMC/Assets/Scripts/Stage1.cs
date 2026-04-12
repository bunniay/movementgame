using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    public string tutorialSceneName = "scenechanger";

    public void SceneChange()
    {
        SceneManager.LoadScene(tutorialSceneName);
    }
}