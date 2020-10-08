using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMinorController : MonoBehaviour
{
    [SerializeField]
    RuntimeAnimatorController explosion;

    [SerializeField]
    float explosionTime;

    private float timer = 0.0f;
    private bool kill = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            GetComponent<Animator>().runtimeAnimatorController = explosion;

            Destroy(collision.gameObject);
            kill = true;

            // Stop the zombie from moving
            gameObject.GetComponent<AIPath>().enabled = false;
            
            // Prevent the player from getting points by killing a dead zombie (until we destroy the game object)
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
        }
        //Debug.Log("Hi!");
    }
}
