using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    public AudioClip clickSound;
    [SerializeField] private AudioClip gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        PlayClickSound(clickSound);
        SceneManager.LoadScene(1);
        AudioManager.Instance._musicSource.clip = gameMusic;    
        AudioManager.Instance._musicSource.Play();
    }
    
    public void Settings()
    {
        PlayClickSound(clickSound);
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    
    public void BackToMainMenu()
    {
        PlayClickSound(clickSound);
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void Quit()
    {
        PlayClickSound(clickSound);

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }

    public void PlayClickSound(AudioClip clip)
    {
        AudioManager.Instance.PlaySound(clip);
    }

}
