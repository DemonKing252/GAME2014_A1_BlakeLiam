﻿using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
File: ZombieMinorController.cs
Author: Liam Blake
Created: 2020-09-28
Modified: 2020-10-11
Desc:
Manager for every zombie (tier: minor).

*/
public class ZombieMinorController : MonoBehaviour
{
    [SerializeField]
    RuntimeAnimatorController explosion;

    [SerializeField]
    GameObject diamond;

    [SerializeField]
    float explosionTime;

    [SerializeField]
    float m_health;

    [SerializeField]
    float pointsWorth;

    [SerializeField]
    GameObject goldObj;

    [SerializeField]
    GameObject text;

    private PlayerController pScript;

    private GameScript gScript;

    private float timer = 0.0f;
    private bool kill = false;

    

    // Start is called before the first frame update
    void Start()
    {
        pScript = FindObjectOfType<PlayerController>();
        gScript = FindObjectOfType<GameScript>();
        //currentHealth = m_health;
    }

    // Update is called once per frame 
    void Update()
    {
        if (Vector3.Magnitude(GetComponent<AIPath>().velocity) <= 0.1f && GetComponent<AIPath>().enabled == true)
            GetComponent<Animator>().enabled = false;
        else
            GetComponent<Animator>().enabled = true;

        if (kill)
        {
            timer += Time.deltaTime;
        }
        if (timer >= explosionTime)
        {
            // Instantiate a score text with the amount of points that this game object is worth when destroyed/collected.
            text.GetComponent<TextMesh>().text = "+" + pointsWorth.ToString("F0");
            Instantiate(text, gameObject.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
            int rand = Random.Range(0, 100);

            // 10% chance for a gold drop
            if (rand <= 10)
                Instantiate(goldObj, gameObject.transform.position, Quaternion.identity);

            int rand2 = Random.Range(0, 100);

            // 5% for a diamond drop
            if (rand2 <= 5)
                Instantiate(diamond, gameObject.transform.position, Quaternion.identity);
        }
        //Debug.Log(pScript.bulletDamage);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            m_health -= pScript.bulletDamage;

            if (m_health <= 0.0f)
            {
                gScript.explode.Play();
                //explode.volume = 25.0f;
                //explode.Play();

                gScript.UpdateScoreText(pointsWorth);
                kill = true;

                GetComponent<Animator>().runtimeAnimatorController = explosion;
                // Stop the zombie from moving
                gameObject.GetComponent<AIPath>().enabled = false;

                // Prevent the player from getting points by killing a dead zombie (until we destroy the game object)
                gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
            Destroy(collision.gameObject);
            
        }
 
    }
}
