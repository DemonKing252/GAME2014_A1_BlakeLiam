using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
File: BulletController.cs
Author: Liam Blake
Created: 2020-10-11
Modified: 2020-10-11
Desc:
    Manager for every bullet that is fired by the player.

*/

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float speed;


    [System.Obsolete]
    void Start()
    {
        //Debug.Log("Bullet created!");
        GetComponent<Rigidbody2D>().velocity *= speed;


    }

    // Update is called once per frame
    void Update()
    {
        // Check if the object left the scene
        CheckBounds();
    }
    private void CheckBounds()
    {
        
        bool destroy = false;
        if (gameObject.transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.safeArea.height, 0.0f)).y)
            destroy = true;
        else if (gameObject.transform.position.y <= -Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.safeArea.height, 0.0f)).y)
            destroy = true;
        else if (gameObject.transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width, 0.0f, 0.0f)).x)
            destroy = true;
        else if (gameObject.transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width, 0.0f, 0.0f)).x)
            destroy = true;

        if (destroy)
            Destroy(gameObject);
    }
}
