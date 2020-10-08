using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float speed;

    private float angle;
    private Vector3 rotation;
    // Start is called before the first frame update

    private Vector2 delta;
    [System.Obsolete]
    void Start()
    {
        rotation = gameObject.transform.rotation.ToEulerAngles();
        angle = rotation.z + Mathf.PI / 2.0f;

        gameObject.transform.rotation = Quaternion.EulerAngles(0.0f, 0.0f, angle + Mathf.PI / 2.0f);

        delta = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        Debug.Log("Bullet created!");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rotation.ToString());
        gameObject.transform.position += new Vector3(delta.x, delta.y, 0.0f) * (speed * Time.deltaTime);

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
