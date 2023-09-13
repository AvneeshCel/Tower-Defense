using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    [SerializeField] public AudioSource _musicSource, _effectsSource;
    public AudioClip clickSound;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Audio Manager is NULL!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    public void PlayClick()
    {
        _effectsSource.PlayOneShot(clickSound);
    }

    public void ChangeMasterVolume(float value)
    {
        PlayerPrefs.SetFloat("MasterVolume", value);
        AudioListener.volume = value;
    }
    
    public void ChangeMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        _musicSource.volume = value;
    }
    
    public void ChangeEffectsVolume(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
        _effectsSource.volume = value;
    }

    
}
