using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapScript : MonoBehaviour {
    /// <summary>
    /// Script to wrap the ship
    /// </summary>

    //Declare mins and max for screen width and height
    float minX = -20;
    float minY = -20;
    float maxX = 20;
    float maxY = 20;
    
	// Update is called once per frame
	void Update ()
    {
        //Declare limits
        float positionX = transform.position.x;
        float positionY = transform.position.y;

        //Test for X axis wrap
        if (positionX < minX)
        {
            positionX = maxX;
        }
        else if(positionX > maxX)
        {
            positionX = minX;
        }
        
        //Test for y axis wrap
        if (positionY < minY)
        {
            positionY = maxY;
        }
        else if (positionY > maxY)
        {
            positionY = minY;
        }

        //Transform to new position
        transform.position = new Vector3(positionX, positionY, transform.position.z);
    }
}
