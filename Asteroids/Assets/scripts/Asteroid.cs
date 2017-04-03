using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An Asteroid
/// </summary>
public class Asteroid : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //apply impulse force
        const float ImpulseForceRange = 2f;
        const float MinImpulseForce = 3f;
        GetComponent<Rigidbody2D>().AddForce(
            Random.insideUnitCircle * ImpulseForceRange +
            new Vector2(MinImpulseForce, MinImpulseForce),
            ForceMode2D.Impulse);
    }

}
