using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoader;
    
    public void Restart()
    {
        StartCoroutine(levelLoader.Replay());
    }
}
