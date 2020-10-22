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
    public AudioSource theme;

    [SerializeField]
    Text text;

    [SerializeField]
    GameScript gScript;
    

    public void PlayAgain()
    {
        SceneManager.LoadScene((int)Scene.Game);
        Utilities.scenesChanged++;


        gScript.UpdateScoreText(-Player.score);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);

        Utilities.scenesChanged++;


        gScript.UpdateScoreText(-Player.score);
    }

    // Start is called before the first frame update
    void Start()
    {
        gScript = FindObjectOfType<GameScript>();


        text.text = "Your Score: " + Player.score.ToString();

        theme.Play();

        if (Utilities.scenesChanged == 0)
        {
            SceneManager.LoadScene((int)Scene.MainMenu);
        }
        Utilities.scenesChanged++;
    }

}
