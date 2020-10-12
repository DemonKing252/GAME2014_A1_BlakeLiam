using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
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
    float explosionTime;

    [SerializeField]
    float m_health;

    [SerializeField]
    float pointsWorth;

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
        
        if (kill)
        {
            timer += Time.deltaTime;
        }
        if (timer >= explosionTime)
        {
            Destroy(this.gameObject);
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
