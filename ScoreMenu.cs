using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] public TextMeshProUGUI totalScoreText;
    [SerializeField] public TextMeshProUGUI timeScoreText;
    [SerializeField] public TextMeshProUGUI artifactsScoreText;
    [SerializeField] public Timer timer;
    [SerializeField] public EndLine endLine;
    [SerializeField] public TextMeshProUGUI highScore;
    [SerializeField] public LevelLoader levelLoader;

    [Header("Time Points")]
    public int maxScore = 100;
    public int maxTime = 300;
    private float timeScore;
    private float timeTaken;
    private float totalScore;

    [Header("Artifacts Points")]
    public float artifactsScore;
    public float artifact1Points = 500;
    public float artifact2Points = 700;
    public bool artifact1Collected = false;
    public bool artifact2Collected = false;
    private bool artifactsScoreAdded = false;

    void Start()
    {
        // Load high score for the current level
        string levelName = SceneManager.GetActiveScene().name;
        highScore.text = PlayerPrefs.GetFloat("HighScore_" + levelName, 0).ToString();
    }

    private void Update()
    {
        if (!timer.timerRunning)
        {
            // Calculate time score
            timeTaken = maxTime - timer.timeLeft;
            timeScore = Mathf.RoundToInt(maxScore - (timeTaken / maxTime) * maxScore);
            timeScoreText.text = ("Time Bonus: " + timeScore);

            // Calculate artifacts score
            if (!artifactsScoreAdded) // Check if the points have been added
            {
                artifactsScore = 0; // Reset the artifacts score

                if (artifact1Collected)
                {
                    artifactsScore += artifact1Points;
                }
                if (artifact2Collected)
                {
                    artifactsScore += artifact2Points;
                }

                artifactsScoreText.text = ("Rare Item Bonus: " + artifactsScore);

                artifactsScoreAdded = true; // Set the flag to indicate points have been added
            }

            totalScore = timeScore + artifactsScore;
            totalScoreText.text = ("Score: " + totalScore);

            // Save high score for the current level
            string levelName = SceneManager.GetActiveScene().name;
            if (totalScore > PlayerPrefs.GetFloat("HighScore_" + levelName, 0))
            {
                PlayerPrefs.SetFloat("HighScore_" + levelName, totalScore);
                highScore.text = totalScore.ToString();
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        StartCoroutine(levelLoader.LoadLevel());
    }

    public void LoadMenu()
    {
        StartCoroutine(levelLoader.LoadMenu());
    }
}