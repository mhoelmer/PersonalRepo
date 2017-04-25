using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An asteroid
/// </summary>
public class Asteroid : MonoBehaviour {

    [SerializeField]
    Sprite asteroidSprite0;
    [SerializeField]
    Sprite asteroidSprite1;
    [SerializeField]
    Sprite asteroidSprite2;

    #region Properties

    /// <summary>
    /// Sets the asteroid location
    /// </summary>
    public Vector2 Location {
        set {
            Vector3 location = transform.position;
            location.x = value.x;
            location.y = value.y;
            transform.position = location;
        }
    }

    /// <summary>
    /// Gets the collider radius for the asteroid
    /// </summary>
    public float ColliderRadius {
        get { return gameObject.GetComponent<CircleCollider2D>().radius; }
    }

    #endregion

    #region Unity methods

    // Use this for initialization
    void Start () {

        // apply impulse force to get asteroid moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);

        // set random sprite for asteroid
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber < 1) {
            spriteRenderer.sprite = asteroidSprite0;
        } else if (spriteNumber < 2) {
            spriteRenderer.sprite = asteroidSprite1;
        } else {
            spriteRenderer.sprite = asteroidSprite2;
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Sets the asteroid to move in the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Direction direction) {
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody2D.velocity;
        switch (direction) {
            case Direction.Left:
                if (velocity.x > 0) {
                    velocity.x *= -1;
                }
                break;
            case Direction.Right:
                if (velocity.x < 0) {
                    velocity.x *= -1;
                }
                break;
            case Direction.Up:
                if (velocity.y < 0) {
                    velocity.y *= -1;
                }
                break;
            case Direction.Down:
                if (velocity.y > 0) {
                    velocity.y *= -1;
                }
                break;
        }
        rigidbody2D.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

    }
    #endregion
}
