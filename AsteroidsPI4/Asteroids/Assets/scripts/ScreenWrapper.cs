using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour {

    // wrapping support
    float halfColliderRadius;

    // Use this for initialization
    void Start () {

        // save for efficiency
        halfColliderRadius = gameObject.GetComponent<CircleCollider2D>().radius / 2;
    }

    /// <summary>
    /// Called when the camera can no longer see the game object
    /// </summary>
    void OnBecameInvisible() {
        Vector2 location = transform.position;

        // check left, right, top, and bottom sides
        if (location.x + halfColliderRadius < ScreenUtils.ScreenLeft ||
            location.x - halfColliderRadius > ScreenUtils.ScreenRight) {
            location.x *= -1;
        }
        if (location.y - halfColliderRadius > ScreenUtils.ScreenTop ||
            location.y + halfColliderRadius < ScreenUtils.ScreenBottom) {
            location.y *= -1;
        }

        // move game object
        transform.position = location;
    }
}
