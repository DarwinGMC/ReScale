using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{   
    [Header("Variables")]
    public static bool GameIsPaused = false;

    [Header("Components")]
    public GameObject pauseMenuUI;
    [SerializeField] GameObject player;
    [SerializeField] GameObject timerText;
    [SerializeField] GameObject pointer;
    [SerializeField] LevelLoader levelLoader;
    [SerializeField] AudioSource tickAudio;
    [SerializeField] Timer timer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup playerPickupScript = player.GetComponent<PhysicsPickup>();    
        playerPickupScript.enabled = true;        
        playerMovScript.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        timerText.SetActive(true);
        pointer.SetActive(true);
        timer.isTicking = true;
    }
    
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup playerPickupScript = player.GetComponent<PhysicsPickup>();    
        playerPickupScript.enabled = false;    
        playerMovScript.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        timerText.SetActive(false);
        pointer.SetActive(false);
        tickAudio.enabled = false;
        timer.isTicking = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(levelLoader.LoadMenu());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
