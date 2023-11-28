using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weighter3 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTMP;
    [SerializeField] private Transform door1;

    private int totalWeight = 0;

    public int heavyWeight;
    public int mediumHeavyWeight;
    public int mediumWeight;
    public int smallMediumWeight;
    public int smallWeight;

    public int weightGoal;

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
        door1.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    void Update()
    {
        if (totalWeight == weightGoal)
        {
            door1.rotation = Quaternion.Euler(0f, -10f, 0f);
        }
        else
        {
            door1.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }
}
