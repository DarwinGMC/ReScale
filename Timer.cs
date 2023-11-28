using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    [SerializeField] private GameObject timeText;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject player;
    [SerializeField] GameObject canvas;    
    [SerializeField] GameObject pointer;
    [SerializeField] AudioSource audioSource;
    [SerializeField] PostProcessVolume postProcessVolume;

    [Header("Timer Settings")]
    public float currentTime;
    public bool timerRunning = true;
    public float timeBonusMultiplier = 10f;
    public float timeLeft;
    public bool isTicking = true;

    [Header("Etc")]
    [SerializeField] private float targetVignetteIntensity = 0.5f;
    [SerializeField] private float vignetteChangeSpeed = 0.1f;
    [SerializeField] private float targetAberrationIntensity = 0.5f;
    [SerializeField] private float aberrationChangeSpeed = 0.1f;
    

    public EndLine endLine;
    private Vignette vignette;
    private ChromaticAberration chromaticAberration;

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
    }
    void Update()
    {
        if (timerRunning && !endLine.stopTimer)
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("0");
        }
        else if (timerRunning)
        {
            timerRunning = false;
            timeLeft = currentTime;
        }

        if (currentTime <= 0)
        {
            MovementScript playerMovScript = player.GetComponent<MovementScript>();
            PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
            PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();
            AudioSource playerWalk = player.GetComponent<AudioSource>();
            timerRunning = false;
            gameOverMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMovScript.enabled = false;
            physicsPickup.enabled = false;
            timeText.SetActive(false);
            pauseMenu.enabled = false;
            pointer.SetActive(false);
            playerWalk.enabled = false;
            audioSource.enabled = false;
            isTicking = false;
            audioSource.enabled = false;
        }

        if (currentTime <= 50 && isTicking)
        {
            if (isTicking)
            {
                audioSource.enabled = true;
            }
            else
            {
                audioSource.enabled = false;
            }
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, targetVignetteIntensity, vignetteChangeSpeed * Time.deltaTime);
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, targetAberrationIntensity, aberrationChangeSpeed * Time.deltaTime);
        }

    }
}