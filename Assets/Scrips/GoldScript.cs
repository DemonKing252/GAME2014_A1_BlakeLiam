using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
File: GoldScript.cs
Author: Liam Blake
Created: 2020-10-12
Modified: 2020-10-12
Desc:
    Manager for the gold loot that can be picked up.
*/
public class GoldScript : MonoBehaviour
{
    private float time = 0.0f;

    private GameScript gScript;

    [SerializeField]
    float pointsWorth;


    // Start is called before the first frame update
    void Start()
    {
        gScript = FindObjectOfType<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 5.0f)
        {
            Destroy(gameObject);
        }

        foreach (var touch in Input.touches)
        {
            var wp = Camera.main.ScreenToWorldPoint(touch.position);
            var touchPosition = new Vector2(wp.x, wp.y);

            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
            {
                gScript.pickup.Play();
                gScript.UpdateScoreText(pointsWorth);
                Destroy(gameObject);
            }
        }   
    }

    

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision detected!");
    //}
}
