using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] Transform rareDoor;
    [SerializeField] AudioSource audioSource;

    public float rotation;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RareDoor"))
        {
            rareDoor.rotation = Quaternion.Euler(0f, rotation, 0);
            audioSource.enabled = true;
        }
    }
}
