using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField]
    GameObject text;

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

            if (GetComponent<Collider2D>().OverlapPoint(touchPosition))
            {
                // Instantiate a score text with the amount of points that this game object is worth when destroyed/collected.
                text.GetComponent<TextMesh>().text = "+" + pointsWorth.ToString("F0");
                Instantiate(text, gameObject.transform.position, Quaternion.identity);


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
