using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/********************
File: EnemySpriteScript.cs
Author: Liam Blake
Created: 2020-09-26
Modified: 2020-10-14
Desc:
    Manager for the game scene.

********************/
public class EnemySpriteScript : MonoBehaviour
{
    [SerializeField]
    RuntimeAnimatorController explosionAnimator;

    [SerializeField]
    GameObject goldObj;

    [SerializeField]
    float animationClipTime;

    [SerializeField]
    float health;

    [SerializeField]
    float pointsWorth;

    [SerializeField]
    GameObject text;

    private GameScript gScript;
    private PlayerController pScript;

    // Time how long it takes to finish the explosion animation. When it finishes, we destroy the game object.
    private float m_time = 0.0f;
    private bool startExplosion;

    // Start is called before the first frame update
    void Start()
    {
        gScript = FindObjectOfType<GameScript>();
        pScript = FindObjectOfType<PlayerController>();

        // Flip the sprite Y-axis so its not facing backwards.
        gameObject.transform.localScale = new Vector3(1, -1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (startExplosion)
        {
            m_time += Time.deltaTime;

            if (m_time >= animationClipTime)
            {
                // Instantiate a score text with the amount of points that this game object is worth when destroyed/collected.
                text.GetComponent<TextMesh>().text = "+" + pointsWorth.ToString("F0");
                Instantiate(text, gameObject.transform.position, Quaternion.identity);
                
                Destroy(gameObject);

                int rand = Random.Range(0, 100);

                // 10% chance for a gold drop
                if (rand <= 10)
                    Instantiate(goldObj, gameObject.transform.position, Quaternion.identity);

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= pScript.bulletDamage;
            Destroy(collision.gameObject);

            if (health <= 0.0f)
            {
                gScript.explode.Play();

                gScript.UpdateScoreText(pointsWorth);
                startExplosion = true;
                GetComponent<Animator>().runtimeAnimatorController = explosionAnimator;

                // Stop the zombie from moving
                gameObject.GetComponent<AIPath>().enabled = false;

                // Prevent the player from getting points by killing a dead zombie (until we destroy the game object)
                gameObject.GetComponent<Rigidbody2D>().simulated = false;

            }
        }
    }

}
