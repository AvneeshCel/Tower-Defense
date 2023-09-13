using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.ChangeMasterVolume(PlayerPrefs.GetFloat("MasterVolume"));
        _masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        AudioManager.Instance.ChangeMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        AudioManager.Instance.ChangeEffectsVolume(PlayerPrefs.GetFloat("SFXVolume"));
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        _masterSlider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMasterVolume(val));
        _musicSlider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMusicVolume(val));
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
        _sfxSlider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeEffectsVolume(val));
        PlayerPrefs.SetFloat("SFXVolume", _sfxSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
