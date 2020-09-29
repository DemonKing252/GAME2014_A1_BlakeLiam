using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*************************************************
File: CameraScript_Menu.cs
Author: Liam Blake
Created: 2020-09-29
Modified: 2020-09-29
Desc:
    Manager for the camera for this scene.
*************************************************/
public class CameraScript_Menu : MonoBehaviour
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
            Screen.SetResolution((int)(1440* ResolutionScaleX), 2560, true);
        }
        else
        {
            Screen.SetResolution(1440, 2560, true);
        }
    }
}
