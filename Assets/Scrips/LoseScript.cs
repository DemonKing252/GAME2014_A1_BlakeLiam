using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*********************
File: LoseScript.cs
Author: Liam Blake
Created: 2020-09-22
Modified: 2020-10-12
Desc:
    Manager for the lose scene of this game.

*********************/

public class LoseScript : MonoBehaviour
{
    [SerializeField]
    AudioSource theme;

    [SerializeField]
    Text text;

    [SerializeField]
    AudioSource click;

    public void PlayAgain()
    {
        click.Play();
        SceneManager.LoadScene((int)Scene.Game);
        Utilities.scenesChanged++;


    }
    public void BackToMenu()
    {
        click.Play();
        SceneManager.LoadScene((int)Scene.MainMenu);
        Utilities.scenesChanged++;

    }

    // Start is called before the first frame update
    void Start()
    {


        text.text = "Your Score: " + Player.score.ToString();

        theme.Play();

        if (Utilities.scenesChanged == 0)
        {
            SceneManager.LoadScene((int)Scene.MainMenu);
        }
        Utilities.scenesChanged++;
    }

}
