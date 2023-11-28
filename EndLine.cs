using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndLine : MonoBehaviour
{
    public bool stopTimer = false;
    [SerializeField] public GameObject wonMenu;
    [SerializeField] public TextMeshProUGUI timerText;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject canvas;
    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private AudioSource tickAudio;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject pointer;
 
    private void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wonMenu.SetActive(true);
            stopTimer = true;
            timerText.gameObject.SetActive(false);
            UnlockNewLevel();
            tickAudio.enabled = false;

            MovementScript playerMovScript = playerObject.GetComponent<MovementScript>();
            PhysicsPickup physicsPickup = playerObject.GetComponent<PhysicsPickup>();
            PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();
            if (playerMovScript != null)
            {
                playerMovScript.enabled = false;
                playerAudio.enabled = false;
                physicsPickup.enabled = false;
                pauseMenu.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pointer.SetActive(false);
            }
            timer.isTicking = false;
        }
    }

    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
