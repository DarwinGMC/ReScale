using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI; // Import the UI namespace

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sensitivitySlider;
    public MovementScript movementScript;

    void Start()
    {

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetSensitivity(float sensitivity)
    {
        // Save the sensitivity value to PlayerPrefs
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        PlayerPrefs.Save();
        
        // Update the sensitivity in the MovementScript
        movementScript.SetSensitivity(sensitivity);
    }
}