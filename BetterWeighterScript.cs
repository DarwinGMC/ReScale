using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetterWeighterScript : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI textTMP;
    [SerializeField] private Transform door1;
    [SerializeField] private AudioSource keyAudio;
    [SerializeField] private AudioSource doorAudio;
    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private AudioClip doorClose;

    [Header("WeightValues")]

    public int weightGoal;

    private int totalWeight = 0;

    private int heavyWeight = 30;
    private int mediumHeavyWeight = 20;
    private int mediumWeight = 15;
    private int smallMediumWeight = 5;
    private int smallWeight = 1;

    [Header("DoorRot")]
    public float xRot;
    public float yRot;
    public float zRot;

    public float opXRot;
    public float opYRot;
    public float opZRot;

    private bool doorOpened = false;

    private void UpdateText()
    {
        textTMP.text = totalWeight + "lbs";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Heavy"))
        {
            totalWeight += heavyWeight;
            UpdateText();
        }
        else if (collision.gameObject.CompareTag("Medium Heavy"))
        {
            totalWeight += mediumHeavyWeight;
            UpdateText();
        }
        else if (collision.gameObject.CompareTag("Medium"))
        {
            totalWeight += mediumWeight;
            UpdateText();
        }
        else if (collision.gameObject.CompareTag("Small Medium"))
        {
            totalWeight += smallMediumWeight;
            UpdateText();
        }
        else if (collision.gameObject.CompareTag("Small"))
        {
            totalWeight += smallWeight;
            UpdateText();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Heavy"))
        {
            totalWeight -= heavyWeight;
            UpdateText();
        }
        else if (collision.gameObject.CompareTag("Medium Heavy"))
        {
            totalWeight -= mediumHeavyWeight;
            UpdateText();
        }
        else if (collision.gameObject.CompareTag("Medium"))
        {
            totalWeight -= mediumWeight;
            UpdateText();
        }
        else if (collision.gameObject.CompareTag("Small Medium"))
        {
            totalWeight -= smallMediumWeight;
            UpdateText();
        }
        else if (collision.gameObject.CompareTag("Small"))
        {
            totalWeight -= smallWeight;
            UpdateText();
        }
    }

    void Start()
    {
        UpdateText();
        door1.rotation = Quaternion.Euler(xRot, yRot, zRot);
    }

    void Update()
    {
        if (totalWeight == weightGoal && !doorOpened)
        {
            door1.rotation = Quaternion.Euler(opXRot, opYRot, opZRot);
            doorAudio.PlayOneShot(doorOpen);
            doorOpened = true;
        }
        else if (totalWeight != weightGoal && doorOpened)
        {
            door1.rotation = Quaternion.Euler(xRot, yRot, zRot);
            doorAudio.PlayOneShot(doorClose);
            doorOpened = false;
        }

        if (totalWeight == weightGoal)
        {
            textTMP.color = Color.green;
        }
        else if (totalWeight >= weightGoal * 0.75f && totalWeight <= weightGoal * 1.25f)
        {
            textTMP.color = Color.yellow;
        }        
        else if (totalWeight >= weightGoal * 0.50f && totalWeight <= weightGoal * 1.50f)
        {
            textTMP.color = new Color(1f, 0.647f, 0f);
        }
        else
        {
            textTMP.color = Color.red;
        }
    }
}
