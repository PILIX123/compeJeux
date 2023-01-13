using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseEvents : MonoBehaviour
{
    public Sprite SwitchOff, SwitchOn;

    private void Start()
    {
        Debug.Log(gameManager.instance.colour);
    }

    public void PlayGame()
    {
        if (gameManager.instance.skip == true)
            SceneManager.LoadScene("MainMap");
        else
            SceneManager.LoadScene("Tutorial");
    }
    public void QuitGame()
    {
#if DEBUG
        UnityEditor.EditorApplication.isPlaying = false;
#endif
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
        if (gameManager.instance.colour == false)
        {
            button.GetComponent<Image>().sprite = SwitchOn;
            gameManager.instance.colour = true;
        }
        else
        {
            button.GetComponent<Image>().sprite = SwitchOff;
            gameManager.instance.colour = false;
        }
    }
    public void skipTuto()
    {
        Button button = GameObject.FindGameObjectWithTag("SwitchTuto").GetComponent<Button>();
        if (gameManager.instance.skip == false)
        {
            button.GetComponent<Image>().sprite = SwitchOn;
            gameManager.instance.skip = true;
        }
        else
        {
            button.GetComponent<Image>().sprite = SwitchOff;
            gameManager.instance.skip = false;
        }

    }
}
