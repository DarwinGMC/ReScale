using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialWeighterScript : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI textTMP;
    [SerializeField] private Transform door1;

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

    [Header("DoorPos")]
    public float xPos;
    public float yPos;
    public float zPos;

    public float opXPos;
    public float opYPos;
    public float opZPos;

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
        door1.position = new Vector3(xPos, yPos, zPos);      
    }

    void Update()
    {
        if (totalWeight == weightGoal)
        {
            door1.rotation = Quaternion.Euler(opXRot, opYRot, opZRot);
            door1.position = new Vector3(opXPos, opYPos, opZPos);
        }
        else
        {
            door1.rotation = Quaternion.Euler(xRot, yRot, zRot);
            door1.position = new Vector3(xPos, yPos, zPos);
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
