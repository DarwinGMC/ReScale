using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void GoingToPlayMenu()
    {
        animator.SetBool("iAmMenuV2", false);
    }

    public void GoingToMenu()
    {
        animator.SetBool("iAmMenuV2", true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitted");
    }

    public void GoingToMainMenu()
    {
        animator.SetBool("iAmMenu", true);
    }

    public void GoingToOptionsMenu()
    {
        animator.SetBool("iAmMenu", false);
    }
}
