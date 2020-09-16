﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/***************
File: MainMenuScript.cs
Author: Liam Blake
Created: 2020-09-15
Modified: 2020-09-15

Purpose:
    Handles the events of the main menu buttons

***************/
public class MainMenuScript : MonoBehaviour
{
    // Called when Start Game button is pressed:
    public void StartGame()
    {
        Debug.Log("Leaving Main Menu Scene...");
        SceneManager.LoadScene(1);
    }

    // Called when Quit Game button is pressed:
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;            
    #else   
        Application.Quit();
    #endif
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}