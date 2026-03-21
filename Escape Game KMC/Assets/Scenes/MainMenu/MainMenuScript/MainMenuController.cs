using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject aboutPopup;
    [SerializeField] private GameObject mainButtons; 

    public void OnStartClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnSettingsClick()
    {
        settingsPanel.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void OnSettingsBack()
    {
        settingsPanel.SetActive(false);
        mainButtons.SetActive(true);
    }

    public void OnAboutClick()
    {
        aboutPopup.SetActive(true);
    }

    public void OnAboutClose()
    {
        aboutPopup.SetActive(false);
    }
}