using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float enemyspeed;
    private Rigidbody2D enemyrigidbody;
    private BoxCollider2D collider;
    [SerializeField]
    private GameObject deathEffect;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        enemyrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyrigidbody.velocity = new Vector2(enemyspeed, 0f);
        ReflectCharacterSprite();
    }

    private void ReflectCharacterSprite()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {

            Debug.Log("aaaa");
            enemyspeed = -enemyspeed;
            enemyrigidbody.velocity = new Vector2(enemyspeed, 0f);
            Vector3 scale = transform.localScale;
            scale.x = scale.x * (-1);
            transform.localScale = scale;
        }
    }

    public void Death()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);


    }

}

