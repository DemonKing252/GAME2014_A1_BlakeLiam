using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************
File: CameraScript_Difficulty.cs
Author: Liam Blake
Created: 2020-10-01
Modified: 2020-10-01
Desc:
   Manager for the camera for this scene.
***************/
public class CameraScript_Difficulty : MonoBehaviour
{
    public float ResolutionScaleX = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Screen.orientation == ScreenOrientation.LandscapeLeft ||
            Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            Screen.SetResolution((int)(1440 * ResolutionScaleX), 2560, true);
        }
        else
        {
            Screen.SetResolution(1440, 2560, true);
        }
    }
}
