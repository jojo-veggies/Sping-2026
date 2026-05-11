using System;
using TMPro;
using UnityEngine;

public class SettingsControl : MonoBehaviour
{
    //Various ways to access in-game objects to update.
    [SerializeField] AudioSource musicToggle;
    [SerializeField] TMP_Text musicText;
    [SerializeField] AudioSource soundEffectsToggle;
    [SerializeField] TMP_Text soundEffectText;
    [SerializeField] GameObject optionsScreen;
    [SerializeField] GameObject pauseScreen;
    //Records if music or sound is on.
    private Boolean musicOn;
    private Boolean soundEffectsOn;
    //Static variables to ensure every scene has the same settings
    static bool isMusicOn;
    static Boolean isSoundEffectsOn;
    private void Start()
    {
        //Updates when scene loads so the previous scene's settings apply.
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

    //Used in the MainMenuController to automatically turn music/sound effects on
    public void forStart()
    {
        isMusicOn = true;
        isSoundEffectsOn = true;
    }

    //Opens the options screen.
    public void openOptions()
    {
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    //Goes back to the pause screen.
    public void closeOptions()
    {
        pauseScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    //Toggles the music's volume on or off.
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

    //Toggles sound effects on or off.
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
