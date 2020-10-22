using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
File:       ForegroundController.cs
Author:     Liam Blake
Created:    2020-10-22
Modified:   2020-10-22
Desc:
    Destroys objects that touch the foreground objects (rocks, bushes, trees etc).

*/ 
public class ForegroundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
