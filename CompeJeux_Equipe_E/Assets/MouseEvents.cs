using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseEvents : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainMap");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
