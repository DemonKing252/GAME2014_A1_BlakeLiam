using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
File: ScoreScript.cs
Author: Liam Blake
Created: 2020-09-36
Modified: 2020-09-36
Desc:
    Manager for our score text on screen.

*/
public class ScoreScript : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        // demo score:
        text.text = "Score: " + Utilities.score.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
