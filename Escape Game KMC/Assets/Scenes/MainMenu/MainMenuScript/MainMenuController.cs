using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; 

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject settingP; 
    [SerializeField] private GameObject aboutP;   
    [SerializeField] private GameObject buttons;  

    [Header("Audio")]
    [SerializeField] private AudioMixer mainMixer; 
    // 1. Start 버튼
    public void OnStartClick()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // 2. Settings 관련
    public void OnSettingsClick()
    {
        settingP.SetActive(true);
        buttons.SetActive(false); 
    }

    public void OnSettingsBack()
    {
        settingP.SetActive(false);
        buttons.SetActive(true);  
    }

    // 3. About 관련
    public void OnAboutClick()
    {
        aboutP.SetActive(true);
    }

    public void OnAboutClose()
    {
        aboutP.SetActive(false);
    }

    // 4. 볼륨 조절 (슬라이더용)
    public void SetVolume(float volume)
    {
        
        mainMixer.SetFloat("MasterVol", Mathf.Log10(volume) * 20);
    }


}