using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;

    [SerializeField] private Transform FeetTransform;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform PlayerCamera;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] public float Sensitivity = 3f;
    [SerializeField] public float defaultSensitivity = 2f;
    [SerializeField] public AudioSource walkSound;

    [Header("Audio Pitch Settings")]
    [SerializeField] private float minPitch = 0.6f;
    [SerializeField] private float maxPitch = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // Read sensitivity from PlayerPrefs and update the Sensitivity field
        Sensitivity = PlayerPrefs.GetFloat("Sensitivity", defaultSensitivity);

        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Set a random pitch within the specified range
            walkSound.pitch = Random.Range(minPitch, maxPitch);
            walkSound.enabled = true;
        }
        else
        {
            walkSound.enabled = false;
        }
    }


    private void MovePlayer() 
    {   
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);
 
    }

    private void MovePlayerCamera ()
    {   
        xRot -= PlayerMouseInput.y * Sensitivity;
        xRot = Mathf.Clamp(xRot, -90f, 90f); 


        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f ,0f);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetSensitivity(float sensitivity)
    {
        Sensitivity = sensitivity;
    }
}