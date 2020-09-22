using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/********************
File: GameScript.cs
Author: Liam Blake
Created: 2020-09-21
Modified: 2020-09-21
Desc:
    Manager for the game scene. For now we have no game logic yet 

********************/
public class GameScript : MonoBehaviour
{
    // Call Lose state (to prove it works)
    public void LoseState()
    {
        // Index 3 is lose scene (look in Unity->File->Build Settings->Scenes in Build
        SceneManager.LoadScene(3);
    }


    // Start is called before the first frame update
    void Start()
    {
        // Liam's note:
        // To prevent the player from entering this scene first. The player should enter the main menu scene first!!
        // When this is packaged it won't matter, but for the purpose of the assignment 
        if (Utilities.scenesChanged == 0)
        {
            SceneManager.LoadScene(0);
        }
        Utilities.scenesChanged++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
