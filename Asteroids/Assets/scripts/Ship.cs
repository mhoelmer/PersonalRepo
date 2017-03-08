using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controlling the Ship
/// </summary>
public class Ship : MonoBehaviour {

    //Declare field to hold Rigidbody2D component
    private Rigidbody2D myRigidBody2D;

    //Declare field to hold thrustDirection
    private Vector2 thrustDirection = new Vector2(1f,0f);

    //Declare Rotation Amount
    const int rotateDegPerSec = 100;

    //Declare constant thrustForce
    const int thrustForce = 10;

	// Use this for initialization
	void Start ()
    {
        //Set field to Rigidbody2D attached to ship
        myRigidBody2D = GetComponent<Rigidbody2D>();

        //Add thrustDirection

    }
	
	// Update is called once per frame
	void Update () {

        float rotationInput = Input.GetAxisRaw("Rotate");
        float rotationAmount = rotateDegPerSec * Time.deltaTime;
        if(rotationInput == 0)
        {
            rotationAmount *= 0;
        }
        else if(rotationInput == 1)
        {
            rotationAmount *= -1;
        }
        else if (rotationInput == -1)
        {
            rotationAmount *= 1;
        }

        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
