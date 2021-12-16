using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public bool deathOccured;
    // Cinemachine Shake
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        deathOccured = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D colliderInfo) 
    {
        Enemy enemy = colliderInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            deathOccured = true;
            enemy.Death();
        }
        Destroy(gameObject);
    }
   
}
