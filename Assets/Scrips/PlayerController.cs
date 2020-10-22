using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform playerCentreLocation;

    [SerializeField]
    float delayBetweenFiring;

    [SerializeField]
    GameScript gScene;

    [SerializeField]
    public float bulletDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float time = 0.0f;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        //gScene.UpdateScoreText(1.0f);

        time += Time.deltaTime;
        foreach (var touch in Input.touches)
        {
            var touchWorldSpace = Camera.main.ScreenToWorldPoint(touch.position);

            Quaternion rot = Quaternion.identity;

            // These functions have lots of issues
            /***
                float angle = Vector3.AngleBetween(gameObject.transform.position, touchWorldSpace);
            ***/

            Vector2 delta = touchWorldSpace - gameObject.transform.position;

            delta.Normalize();

            float angle = Mathf.Atan2(delta.y, delta.x) - (Mathf.PI / 2.0f);

            rot.SetEulerRotation(0.0f, 0.0f, angle);

            gameObject.transform.rotation = rot;

            if (time >= delayBetweenFiring)
            {
                gScene.fire.Play();
                //fire.Play();
                time = 0.0f;
                GameObject go = Instantiate(bulletPrefab, playerCentreLocation.position, rot);
                go.GetComponent<Rigidbody2D>().velocity = delta;
            }
        }

        GameObject[] gos_in_zombie_minor = GameObject.FindGameObjectsWithTag("ZombieMinor");

        foreach (var iter in gos_in_zombie_minor)
        {
            if (gameObject.GetComponent<BoxCollider2D>().IsTouching(iter.GetComponent<Collider2D>()))
            {
                Player.health -= 7.5f * Time.deltaTime;
                gScene.health.text = Player.health.ToString("F0");
            }
        }
        GameObject[] gos_in_zombie_major = GameObject.FindGameObjectsWithTag("ZombieMajor");

        foreach (var iter in gos_in_zombie_major)
        {
            if (gameObject.GetComponent<BoxCollider2D>().IsTouching(iter.GetComponent<Collider2D>()))
            {
                Player.health -= 15.0f * Time.deltaTime;
                gScene.health.text = Player.health.ToString("F0");
            }
        }
        if (Player.ready == true && Player.health <= 0.0f && Utilities.scenesChanged >= 2)
        {
            // prevent the lose scene from being loaded immediately. since the 
            // level of health isn't determined until start() on game scene. and there is no 
            // guarantee that Player.Update() and GameScript.Start() are synced. So Player.Update could be called first
            // before the difficulty is determined
            Player.ready = false;   
            // reset the score back to zero.

            SceneManager.LoadScene((int)Scene.Lose);
        }
    }
    
}
