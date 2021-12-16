using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button start;
    public Button easy;
    public Button normal;
    public Button hard;
    public Button quit_1;
    public Button quit_2;

    public void ClickOn()
    {
        if(easy != null)
            easy.gameObject.SetActive(true);
        if (normal != null)
            normal.gameObject.SetActive(true);
        if (hard != null)
            hard.gameObject.SetActive(true);
        if (quit_1 != null)
            quit_1.gameObject.SetActive(false);
        if (quit_2 != null)
            quit_2.gameObject.SetActive(true);
    }

    public void GameStart()
    {
        if (easy != null)
            easy.gameObject.SetActive(false);
        if (normal != null)
            normal.gameObject.SetActive(false);
        if (hard != null)
            hard.gameObject.SetActive(false);
        if (quit_2 != null)
            quit_2.gameObject.SetActive(false);
        if (quit_1 != null)
            quit_1.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
