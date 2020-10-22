using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/********************
File: GameScript.cs
Author: Liam Blake
Created: 2020-09-21
Modified: 2020-10-11
Desc:
    Manager for the game scene. For now we have no game logic yet 

********************/
[System.Serializable]
public class GameScript : MonoBehaviour
{
    public Text scoreText;

    // Note:
    // I'm not using Text Mesh Pro as my custom font doesn't work for it:
    public Text health;
    public Text msgText;
    public Image healthImage;
    public Image heartImage;

    [SerializeField]
    List<GameObject> m_spawnPoints;

    [SerializeField]
    GameObject zombieMinor;

    [SerializeField]
    GameObject zombieMajor;

    // Call Lose state (to prove it works)
    public void LoseState()
    {
        // Index 3 is lose scene (look in Unity->File->Build Settings->Scenes in Build
        SceneManager.LoadScene((int)Scene.Lose);
        
    }
    public AudioSource fire;
    public AudioSource mainTheme;
    public AudioSource pickup;
    public AudioSource explode;
    private float time;
    private float timeToNext;
    GameObject[] goldFound;
    GameObject[] diamondFound;

    // Start is called before the first frame update
    [System.Obsolete]
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
                Player.health = 50.0f;
                break;
        }
        Player.ready = true;
        
        health.text = Player.health.ToString();


        if (mainTheme != null)
        {
            //mainTheme.Play();
            mainTheme.loop = true;
        }

        time = 0.0f;
        timeToNext = Random.Range(2.0f, 5.0f);


        msgText.text = "You got a gold drop, touch it for bonus points!";
        //msgText.rectTransform.position = new Vector2(0.0f, -2105.0f);

        Player.score = 0.0f;
        UpdateScoreText(0.0f);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        goldFound = GameObject.FindGameObjectsWithTag("Gold");
        diamondFound = GameObject.FindGameObjectsWithTag("Diamond");
        if (goldFound != null || diamondFound != null)
        {
            if (goldFound.Length > 0 && diamondFound.Length == 0)
            {
                msgText.enabled = true;
                msgText.text = "You got a gold drop, touch it for bonus points!";
            }
            else if (diamondFound.Length > 0 && goldFound.Length == 0)
            {
                msgText.enabled = true;
                msgText.text = "You got a diamond drop, touch it for bonus points!";
            }
            else if (diamondFound.Length > 0 && goldFound.Length > 0)
            {
                msgText.enabled = true;
                msgText.text = "You got a diamond and gold drop, touch it for bonus points!";
            }
            else
            {
                msgText.enabled = false;
            }
        } 

        time += Time.deltaTime;
        if (time >= timeToNext)
        {
            time = 0.0f;
            timeToNext = Random.Range(2.0f, 5.0f);

            int index = Random.RandomRange(0, m_spawnPoints.Count);


            // 20% chance for a zombie major (2x health) (75% speed)
            // 80% chance for a zombie minor (1x health) (100% speed) 
            
            int randomZombieSelection = Random.Range(0, 100);
            if (randomZombieSelection <= 20) {
                Instantiate(zombieMajor, m_spawnPoints[index].transform.position, Quaternion.identity);
            }
            else {
                Instantiate(zombieMinor, m_spawnPoints[index].transform.position, Quaternion.identity);
            }
        }

        //Debug.Log(Random.Range(1.0f, 40.0f));

        scoreText.rectTransform.position = new Vector2(Screen.safeArea.xMin + scoreText.rectTransform.rect.width * 0.5f + 20.0f, Screen.safeArea.yMax - scoreText.rectTransform.rect.height * 0.5f - 50.0f);
        health.rectTransform.position = new Vector2(Screen.safeArea.xMin + Screen.safeArea.width * 0.5f + 70.0f, Screen.safeArea.yMax - health.rectTransform.rect.height * 0.5f - 50.0f);
        heartImage.rectTransform.position = new Vector2(Screen.safeArea.xMin + Screen.safeArea.width * 0.5f - 50.0f, Screen.safeArea.yMax - heartImage.rectTransform.rect.height * 0.5f);
        
    }
    public void UpdateScoreText(float addBy)
    {
        Player.score += addBy;

        scoreText.text = "Score: " + Player.score.ToString();
        //Debug.Log("Test");
    }
}
