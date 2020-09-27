using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/********************
File: EnemySpriteScript.cs
Author: Liam Blake
Created: 2020-09-26
Modified: 2020-09-26
Desc:
    Manager for the game scene. For now we have no game logic yet 

********************/
public class EnemySpriteScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
