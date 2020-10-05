using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/********************
File: Utilities.cs
Author: Liam Blake
Created: 2020-09-15
Modified: 2020-09-26
Desc:
    Manager for the game scene. For now we have no game logic yet 

********************/
public enum Scene : int
{
    MainMenu = 0,
    LevelOfDifficulty = 1,
    Instruction = 2,
    Game = 3,
    Lose = 4
};
public enum Difficulty : int
{
    Easy = 1,
    Normal = 2,
    Hard = 3
};
// Access from the lose state to print the health:
public struct Player
{
    public static float health;
    public static float score = 0.0f;
}


public class Utilities : MonoBehaviour
{
    public static Difficulty difficulty;
    public static int scenesChanged = 0;
    // Start is called before the first frame update

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
