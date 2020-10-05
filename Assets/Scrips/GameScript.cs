using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    public Text scoreText;

    // Note:
    // I'm not using Text Mesh Pro as my custom font doesn't work for it:
    public Text health;
    public Image healthImage;
    public Image heartImage;
 

    // Call Lose state (to prove it works)
    public void LoseState()
    {
        // Index 3 is lose scene (look in Unity->File->Build Settings->Scenes in Build
        SceneManager.LoadScene((int)Scene.Lose);
    }
    public AudioSource mainTheme;

    // Start is called before the first frame update
    void Start()
    {
        // Liam's note:
        // To prevent the player from entering this scene first. The player should enter the main menu scene first!!
        // When this is packaged it won't matter, but for the purpose of the assignment 
        if (Utilities.scenesChanged == 0)
        {
            SceneManager.LoadScene((int)Scene.MainMenu);
        }
        Utilities.scenesChanged++;

        switch (Utilities.difficulty)
        {
            case Difficulty.Easy:
                Player.health = 150.0f;
                break;
            case Difficulty.Normal:
                Player.health = 100.0f;
                break;
            case Difficulty.Hard:
                Player.health = 75.0f;
                break;
        }
        health.text = Player.health.ToString();

        if (mainTheme != null)
        {
            mainTheme.volume = 50.0f;
            mainTheme.Play();
            mainTheme.loop = true;
        }
        scoreText.text = "Score: " + Player.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.rectTransform.position = new Vector2(Screen.safeArea.xMin + scoreText.rectTransform.rect.width * 0.5f + 20.0f, Screen.safeArea.yMax - scoreText.rectTransform.rect.height * 0.5f - 50.0f);
        health.rectTransform.position = new Vector2(Screen.safeArea.xMin + Screen.safeArea.width * 0.5f + 70.0f, Screen.safeArea.yMax - health.rectTransform.rect.height * 0.5f - 50.0f);
        heartImage.rectTransform.position = new Vector2(Screen.safeArea.xMin + Screen.safeArea.width * 0.5f - 50.0f, Screen.safeArea.yMax - heartImage.rectTransform.rect.height * 0.5f);
        
    }
}
