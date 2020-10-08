using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform playerCentreLocation;

    [SerializeField]
    float delayBetweenFiring;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float time = 0.0f;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        time += Time.deltaTime;
        foreach (var touch in Input.touches)
        {
            var touchWorldSpace = Camera.main.ScreenToWorldPoint(touch.position);

            Quaternion rot = Quaternion.identity;

            // These functions have lots of issues
            /***
                Vector3 rot2 = Vector3.RotateTowards(gameObject.transform.position, touchWorldSpace, 50.0f, 50.0f);
                float angle = Vector3.AngleBetween(gameObject.transform.position, touchWorldSpace);
            ***/
            Vector2 delta = touchWorldSpace - gameObject.transform.position;

            float angle = Mathf.Atan2(delta.y, delta.x) - (Mathf.PI / 2.0f);

            rot.SetEulerRotation(0.0f, 0.0f, angle);

            gameObject.transform.rotation = rot;

            if (time >= delayBetweenFiring)
            {
                time = 0.0f;
                Instantiate(bulletPrefab, playerCentreLocation.position, gameObject.transform.rotation);
            }
        }
        
    }
}
