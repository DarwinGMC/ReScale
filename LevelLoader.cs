using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private TextMeshProUGUI loadText;
    [SerializeField] private GameObject loadTextGO;
    public float transitionTime = 1f;

    public string[] randomSentences;

    public IEnumerator MainMenuLoad(string levelName)
    {
        transition.SetTrigger("Start");
        NewTextLoad();

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }

    public IEnumerator TutorialLoad()
    {
        transition.SetTrigger("Start");
        NewTextLoad();

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("TutorialLevel");        
    }

    public IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        NewTextLoad();

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator LoadMenu()
    {
        transition.SetTrigger("Start");
        NewTextLoad();

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator Replay()
    {
        transition.SetTrigger("Start");
        NewTextLoad();

        yield return new WaitForSeconds(transitionTime);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void NewTextLoad()
    {
        loadTextGO.SetActive(true);

        string randomSentence = randomSentences[Random.Range(0, randomSentences.Length)];
        loadText.text = randomSentence;
    }
}