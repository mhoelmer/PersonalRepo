using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour
{

    #region Fields

    [SerializeField]
    GameObject prefabBullet;

    #endregion


    // thrust and rotation support
    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float thrustForce = 2;   //10
    const float rotateDegreesPerSecond = 180;

    // Use this for initialization
    void Start()
    {

        // save for efficiency
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // check for rotation input
        float rotationInput = Input.GetAxisRaw("Rotate");
        if (rotationInput != 0)
        {

            // calculate rotation amount and apply rotation
            float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }

        //check shooting input
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            const float forceMagnitude = 10f;
            float angle = transform.eulerAngles.z;
            angle *= Mathf.PI / 180;
            Vector2 forceVector = new Vector2(
                Mathf.Cos(angle) * forceMagnitude,
                Mathf.Sin(angle) * forceMagnitude);
            GameObject bullet = Instantiate<GameObject>(prefabBullet,
                transform.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.ApplyForce(forceVector);

        }
    }

    /// <summary>
    /// Called every fixed framerate frame
    /// </summary>
    void FixedUpdate()
    {

        // thrust as appropriate
        if (Input.GetAxisRaw("Thrust") > 0)
        {
            rb2D.AddForce(thrustDirection * thrustForce,
                ForceMode2D.Force);
        }
    }

    /// <summary>
    /// Destroys the ship when it collides with something
    /// </summary>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
}