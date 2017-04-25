using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A bullet
/// </summary>

public class Bullet : MonoBehaviour {


    Rigidbody2D rb2D;
    const float BulletDeathTimer = 3;
    Timer deathTimer;

	// Use this for initialization
	void Start ()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = BulletDeathTimer;
        deathTimer.Run();
	}
	
    //Update is called once per frame
    void Update()
    {
        //destroy bullet after timer finished
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
    //Applies force
    public void ApplyForce(Vector2 bullet)
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(bullet, ForceMode2D.Impulse);
    }


}
