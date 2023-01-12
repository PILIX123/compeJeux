using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public void ToOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void switchCouleurOn()
    {

    }
    public void skipTuto()
    {

    }
}
