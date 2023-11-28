using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndTutorial : MonoBehaviour
{
    [SerializeField] public GameObject wonTutorial;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject canvas;
    [SerializeField] private AudioSource playerAudio;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wonTutorial.SetActive(true);

            MovementScript playerMovScript = playerObject.GetComponent<MovementScript>();
            PhysicsPickup physicsPickup = playerObject.GetComponent<PhysicsPickup>();
            PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();
            if (playerMovScript != null)
            {
                playerMovScript.enabled = false;
                physicsPickup.enabled = false;
                pauseMenu.enabled = false;

                //cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                playerAudio.enabled = false;

            }
        }
    }
}
