using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject note;
    [SerializeField] private TextMeshProUGUI noteTextUI;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject canvas;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private GameObject paper;
    [SerializeField] private GameObject book1;
    [SerializeField] private GameObject book2;
    [SerializeField] private GameObject book3;

    [SerializeField] AudioSource paperAudio;
    [SerializeField] AudioClip[] soundClips;

    public bool iCanSeeIt = false;
    public bool iAmBedroom = true;
    public bool isANote = true;
    public string customBedText = "This is a hint.";
    public string customGarText = "This is another hint";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (iCanSeeIt && Input.GetKeyDown(KeyCode.E) || iCanSeeIt && Input.GetMouseButtonDown(0) || iCanSeeIt && Input.GetKeyDown(KeyCode.Escape))
        {
            if(isANote)
            {
                HideNote();
            }
            else
            {
                HidePaper();
            }

            HideBook();
            HideBook2();
            HideBook3();
        }

        if(iAmBedroom)
        {
            noteTextUI.text = customBedText;
        }
        else
        {
            noteTextUI.text = customGarText;
        }
    }

    public void ShowNote()
    {        
        note.SetActive(true);

        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
        PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovScript.enabled = false;
        physicsPickup.enabled = false;
        pauseMenu.enabled = false;
        pointer.SetActive(false);

        audioSource.enabled = false;
        
        iCanSeeIt = true;

        PlayRandomSound();
    }

    public void HideNote()
    {
        note.SetActive(false);

        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
        PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovScript.enabled = true;
        physicsPickup.enabled = true;
        pauseMenu.enabled = true;
        pointer.SetActive(true);

        iCanSeeIt = false;

        PlayRandomSound();
    }

    public void ShowPaper()
    {        
        paper.SetActive(true);

        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
        PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovScript.enabled = false;
        physicsPickup.enabled = false;
        pauseMenu.enabled = false;
        pointer.SetActive(false);

        audioSource.enabled = false;
        
        iCanSeeIt = true;

        PlayRandomSound();
    }

    public void HidePaper()
    {
        paper.SetActive(false);

        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
        PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovScript.enabled = true;
        physicsPickup.enabled = true;
        pauseMenu.enabled = true;
        pointer.SetActive(true);

        iCanSeeIt = false;       

        PlayRandomSound(); 
    }

    public void ShowBook()
    {
        book1.SetActive(true);

        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
        PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovScript.enabled = false;
        physicsPickup.enabled = false;
        pauseMenu.enabled = false;
        pointer.SetActive(false);

        audioSource.enabled = false;
        
        iCanSeeIt = true;  

        PlayRandomSound();      
    }

    public void HideBook()
    {
        book1.SetActive(false);

        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
        PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovScript.enabled = true;
        physicsPickup.enabled = true;
        pauseMenu.enabled = true;
        pointer.SetActive(true);

        iCanSeeIt = false;      

        PlayRandomSound();     
    }

    public void ShowBook2()
    {        
        book2.SetActive(true);

        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
        PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovScript.enabled = false;
        physicsPickup.enabled = false;
        pauseMenu.enabled = false;
        pointer.SetActive(false);

        audioSource.enabled = false;
        
        iCanSeeIt = true;    

        PlayRandomSound();   
    }

    public void HideBook2()
    {
        book2.SetActive(false);

        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
        PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovScript.enabled = true;
        physicsPickup.enabled = true;
        pauseMenu.enabled = true;
        pointer.SetActive(true);

        iCanSeeIt = false;

        PlayRandomSound();           
    }    

    public void ShowBook3()
    {       
        book3.SetActive(true);

        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
        PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovScript.enabled = false;
        physicsPickup.enabled = false;
        pauseMenu.enabled = false;
        pointer.SetActive(false);

        audioSource.enabled = false;
        
        iCanSeeIt = true;   

        PlayRandomSound();                
    }

    public void HideBook3()
    {
        book3.SetActive(false);

        MovementScript playerMovScript = player.GetComponent<MovementScript>();
        PhysicsPickup physicsPickup = player.GetComponent<PhysicsPickup>();
        PauseMenu pauseMenu = canvas.GetComponent<PauseMenu>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovScript.enabled = true;
        physicsPickup.enabled = true;
        pauseMenu.enabled = true;
        pointer.SetActive(true);

        iCanSeeIt = false;  

        PlayRandomSound();         
    }   

    void PlayRandomSound()
    {
        if(soundClips.Length > 0)
        {
            int randomIndex = Random.Range(0, soundClips.Length);

            paperAudio.PlayOneShot(soundClips[randomIndex]);
        }
        else
        {
            Debug.LogWarning("No sound clips assigned to the array.");
        }
    }     
}
