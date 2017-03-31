using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour {

    // thrust and rotation support
    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 10;
    const float RotateDegreesPerSecond = 180;

    // NOTE: the instructions say to use information about the collider
    // radius for wrapping. We said that so we can handle corner cases like
    // going almost straight up along the left or right side of the screen,
    // but the collider radius approach doesn't work for an oblong ship. To see 
    // why, make an oblong ship go off the bottom of the screen with the ship 
    // facing to the right. The solution provided here doesn't work in that case 
    // because the top of the collider isn't below the bottom of the screen when the
    // OnBecamInvisible method is called. There's certainly a complicated
    // way to solve this problem using more colliders and code, but we want
    // to keep this project simpler. The easiest approach to use is to use a mostly 
    // round graphic for the ship and make sure the collider is completely inside
    // the ship graphic. If you do that, ship wrapping should work fine
    // wrapping support
    float colliderRadius;

    // Use this for initialization
    void Start () {

        // save for efficiency
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        colliderRadius = gameObject.GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update () {

        // check for rotation input
        float rotationInput = Input.GetAxisRaw("Rotate");
        if (rotationInput != 0) {

            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0) {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }
	}

    /// <summary>
    /// Called every fixed framerate frame
    /// </summary>
    void FixedUpdate () {

        // thrust as appropriate
        if (Input.GetAxisRaw("Thrust") > 0) {
            rb2D.AddForce(thrustDirection * ThrustForce,
                ForceMode2D.Force);
        } 
    }

    /// <summary>
    /// Called when the camera can no longer see the ship
    /// </summary>
    void OnBecameInvisible() {
        Vector2 position = transform.position;

        // check left, right, top, and bottom sides
        if (position.x + colliderRadius < ScreenUtils.ScreenLeft ||
            position.x - colliderRadius > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        if (position.y - colliderRadius > ScreenUtils.ScreenTop ||
            position.y + colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // move ship
        transform.position = position;
    }
}
