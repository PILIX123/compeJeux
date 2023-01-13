using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseEvents : MonoBehaviour
{
    public Sprite SwitchOff, SwitchOn;
    prefs prefs = new prefs();

    public void PlayGame()
    {
        if (prefs.skip == true)
            SceneManager.LoadScene("MainMap");
        else
            SceneManager.LoadScene("Tutorial");
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
        Button button = GameObject.FindGameObjectWithTag("SwitchColor").GetComponent<Button>();
        if (prefs.colour == false)
        {
            button.GetComponent<Image>().sprite = SwitchOn;
            prefs.colour = true;
        }
        else
        {
            button.GetComponent<Image>().sprite = SwitchOff;
            prefs.colour = false;
        }
    }
    public void skipTuto()
    {
        Button button = GameObject.FindGameObjectWithTag("SwitchTuto").GetComponent<Button>();
        if (prefs.skip == false)
        {
            button.GetComponent<Image>().sprite = SwitchOn;
            prefs.skip = true;
        }
        else
        {
            button.GetComponent<Image>().sprite = SwitchOff;
            prefs.skip = false;
        }

    }
}
