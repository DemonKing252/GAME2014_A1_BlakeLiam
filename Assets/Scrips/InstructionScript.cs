using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/***************
File: InstructionScript.cs
Author: Liam Blake
Created: 2020-09-16
Modified: 2020-09-16
Desc:
    Managment of each button in the instruction scene.

***************/
public class InstructionScript : MonoBehaviour
{
    [SerializeField]
    AudioSource mainTheme;

    [SerializeField]
    AudioSource click;

    public void BackToMenu()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);
        Utilities.scenesChanged++;
        click.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Utilities.scenesChanged == 0)
        {
            SceneManager.LoadScene((int)Scene.MainMenu);
        }
        Utilities.scenesChanged++;

        if (mainTheme != null)
            mainTheme.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
