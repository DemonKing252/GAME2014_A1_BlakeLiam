using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
File: ScorePupupController.cs
Author: Liam Blake
Created: 2020-10-14
Modified: 2020-10-14
Desc:
    Script for text popups for score collected.
 
*/
public class ScorePopupController : MonoBehaviour
{
    Color color;
    float y = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        color = gameObject.GetComponent<TextMesh>().color;
    }

    // Update is called once per frame
    void Update()
    {

        if (color.a >= 0.0f)
            color.a -= 1.0f * Time.deltaTime;

        gameObject.GetComponent<TextMesh>().color = color;
        gameObject.transform.position += new Vector3(0.0f, 1.0f * Time.deltaTime, 0.0f);
        y += 1.0f * Time.deltaTime;


        if (y >= 1.5f)
        {
            Destroy(gameObject);
        }

    }
}
