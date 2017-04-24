using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An asteroid spawner
/// </summary>
public class AsteroidSpawner : MonoBehaviour {

    [SerializeField]
    GameObject prefabAsteroid;

    // save spawned asteroid scripts
    Asteroid leftAsteroid;
    Asteroid rightAsteroid;
    Asteroid topAsteroid;
    Asteroid bottomAsteroid;

    // Use this for initialization
    void Start () {

        // create and place asteroids
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        leftAsteroid = asteroid.GetComponent<Asteroid>();
        leftAsteroid.Location = new Vector2(ScreenUtils.ScreenLeft - leftAsteroid.ColliderRadius, 0);
        asteroid = Instantiate<GameObject>(prefabAsteroid);
        rightAsteroid = asteroid.GetComponent<Asteroid>();
        rightAsteroid.Location = new Vector2(ScreenUtils.ScreenRight + rightAsteroid.ColliderRadius, 0);
        asteroid = Instantiate<GameObject>(prefabAsteroid);
        topAsteroid = asteroid.GetComponent<Asteroid>();
        topAsteroid.Location = new Vector2(0, ScreenUtils.ScreenTop + topAsteroid.ColliderRadius);
        asteroid = Instantiate<GameObject>(prefabAsteroid);
        bottomAsteroid = asteroid.GetComponent<Asteroid>();
        bottomAsteroid.Location = new Vector2(0, ScreenUtils.ScreenBottom - bottomAsteroid.ColliderRadius);
    }

    // Update is called once per frame
    void Update() {

        // make sure asteroids are moving in correct directions
        leftAsteroid.SetDirection(Direction.Right);
        rightAsteroid.SetDirection(Direction.Left);
        topAsteroid.SetDirection(Direction.Down);
        bottomAsteroid.SetDirection(Direction.Up);

        // remove this script from the game object
        Destroy(this);
    }

}
