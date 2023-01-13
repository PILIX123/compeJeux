using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseEvents : MonoBehaviour
{
    public Sprite SwitchOff, SwitchOn, CheckOff, CheckOn;
    public Sprite FlowerBlue, FlowerGreen, FlowerPurple;

    private void Start()
    {
        if (Application.loadedLevelName == "OptionsMenu")
            SwitchColor(gameManager.instance.colour);
    }

    private void Update()
    {
        Debug.Log(GameObject.FindGameObjectWithTag("MenuFlower").GetComponent<Animator>().GetInteger("FlowerColor"));
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
    public void SwitchColor(int index)
    {
        gameManager.instance.colour = index;
        Button buttonbleu = GameObject.FindGameObjectWithTag("bleu").GetComponent<Button>();
        Button buttonvert = GameObject.FindGameObjectWithTag("vert").GetComponent<Button>();
        Button buttonmauve = GameObject.FindGameObjectWithTag("mauve").GetComponent<Button>();
        buttonbleu.GetComponent<Image>().sprite = CheckOff;
        buttonvert.GetComponent<Image>().sprite = CheckOff;
        buttonmauve.GetComponent<Image>().sprite = CheckOff;

        if (index == 0)
        {
            buttonbleu.GetComponent<Image>().sprite = CheckOn;
            GameObject.FindGameObjectWithTag("MenuFlower").GetComponent<ChangeFlowerColor>().ChangeColorAnim();
            
        }
        if (index == 1)
        {
            buttonvert.GetComponent<Image>().sprite = CheckOn;
            GameObject.FindGameObjectWithTag("MenuFlower").GetComponent<ChangeFlowerColor>().ChangeColorAnim();
            
        }
        if (index == 2)
        {
            buttonmauve.GetComponent<Image>().sprite = CheckOn;
            GameObject.FindGameObjectWithTag("MenuFlower").GetComponent<ChangeFlowerColor>().ChangeColorAnim();
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

    public void BackToGame(GameObject pauseMenu)
    {
        Time.timeScale = 1;
        gameManager.instance.paused = false;
        pauseMenu.SetActive(false);
    }
}
