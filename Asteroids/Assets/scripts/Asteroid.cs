using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An Asteroid
/// </summary>
public class Asteroid : MonoBehaviour
{
    //ssaved for efficiency
    [SerializeField]
    Sprite whiteSprite;
    [SerializeField]
    Sprite redSprite;
    [SerializeField]
    Sprite greenSprite;

    [SerializeField]
    GameObject asteroid;

    // Use this for initialization
    void Start()
    {
        //set random sprite
        SpriteRenderer spriteRenderer =
            asteroid.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if(spriteNumber < 1)
        {
            spriteRenderer.sprite = whiteSprite;
        }
        else if(spriteNumber <2)
        {
            spriteRenderer.sprite = redSprite;
        }
        else
        {
            spriteRenderer.sprite = greenSprite;
        }
        //apply impulse force
        const float ImpulseForceRange = 2f;
        const float MinImpulseForce = 3f;
        GetComponent<Rigidbody2D>().AddForce(
            Random.insideUnitCircle * ImpulseForceRange +
            new Vector2(MinImpulseForce, MinImpulseForce),
            ForceMode2D.Impulse);
    }

}
