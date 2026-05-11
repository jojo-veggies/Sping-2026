using System;
using TMPro;
using UnityEngine;

public class SettingsControl : MonoBehaviour
{
    [SerializeField] AudioSource musicToggle;
    [SerializeField] TMP_Text musicText;
    [SerializeField] AudioSource soundEffectsToggle;
    [SerializeField] TMP_Text soundEffectText;
    [SerializeField] GameObject optionsScreen;
    [SerializeField] GameObject pauseScreen;
    private Boolean musicOn;
    private Boolean soundEffectsOn;
    static bool isMusicOn;
    static Boolean isSoundEffectsOn;
    private void Start()
    {
        if (isMusicOn == false)
        {
            musicOn = true;
            toggleMusic();
            musicOn = false;
        }
        else
        {
            musicOn = false;
            toggleMusic();
            musicOn = true;
        }
        if (isSoundEffectsOn == false)
        {
            soundEffectsOn = true;
            toggleSoundEffects();
            soundEffectsOn = false;

            
        }
        else
        {
            soundEffectsOn = false;
            toggleSoundEffects();
            soundEffectsOn= true;
        }


    }

    public void forStart()
    {
        isMusicOn = true;
        isSoundEffectsOn = true;
    }
    public void openOptions()
    {
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void closeOptions()
    {
        pauseScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }
    public void toggleMusic()
    {
       
        if (musicOn == true)
        {
            musicOn = false;
            musicToggle.volume = 0;
            musicText.text = "Music: Off";
            isMusicOn = false;
        }
        else
        {
            musicOn = true;
            musicToggle.volume = 100;
            musicText.text = "Music: On";
            isMusicOn = true;
        }
    }

    public void toggleSoundEffects()
    {
        if (soundEffectsOn == true)
        {
            soundEffectsOn = false;
            soundEffectsToggle.volume = 0;
            soundEffectText.text = "Sound Effects: Off";
            isSoundEffectsOn = false;
        }
        else
        {
            soundEffectsOn = true;
            soundEffectsToggle.volume = 100;
            soundEffectText.text = "Sound Effects: On";
            isSoundEffectsOn = true;
        }
    }
}
