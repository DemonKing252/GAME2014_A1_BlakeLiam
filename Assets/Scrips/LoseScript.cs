using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void PlayAgain()
    {
        SceneManager.LoadScene((int)Scene.Game);
        Utilities.scenesChanged++;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);

        Utilities.scenesChanged++;
    }

    // Start is called before the first frame update
    void Start()
    {
        theme.Play();

        if (Utilities.scenesChanged == 0)
        {
            SceneManager.LoadScene((int)Scene.MainMenu);
        }
        Utilities.scenesChanged++;
    }

}
