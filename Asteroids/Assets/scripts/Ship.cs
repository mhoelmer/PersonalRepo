using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Ship
/// </summary>
public class Ship : MonoBehaviour {
    
    //Declare Rotation Amount
    const int rotateDegPerSec = 100;

    //Use this to hold the component

	// Use this for initialization
	void Start ()
    {
        
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
