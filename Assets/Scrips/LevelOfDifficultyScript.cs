using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*************************************
File: LevelOfDifficultyScript.cs
Author: Liam Blake
Created: 2020-10-01
Modified: 2020-10-01
Desc:
    Manager for the level of difficulty scene and all of its buttons.

*************************************/
public class LevelOfDifficultyScript : MonoBehaviour
{
    public AudioSource theme;

    // Start is called before the first frame update
    void Start()
    {
        if (Utilities.scenesChanged == 0)
        {
            SceneManager.LoadScene((int)Scene.MainMenu);
        }
        Utilities.scenesChanged++;

        if (theme != null)
        {
            theme.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Easy()
    {
        Debug.Log("Difficulty Selected: Difficulty.Easy - Starting with 150 health points");
        Utilities.difficulty = Difficulty.Easy;
        SceneManager.LoadScene((int)Scene.Game);
    }
    public void Normal()
    {
        Debug.Log("Difficulty Selected: Difficulty.Normal - Starting with 100 health points");
        Utilities.difficulty = Difficulty.Normal;
        SceneManager.LoadScene((int)Scene.Game);
    }
    public void Hard()
    {
        Debug.Log("Difficulty Selected: Difficulty.Hard - Starting with 75 health points");
        Utilities.difficulty = Difficulty.Hard;
        SceneManager.LoadScene((int)Scene.Game);
    }

}
