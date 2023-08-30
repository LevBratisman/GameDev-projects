using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunFire : MonoBehaviour
{

    public Rigidbody2D rb;

    void Start()
    {
        
    }

    void Update()
    {
        move();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "crown")
            Destroy(gameObject);
    }

    void move()
    {
        rb.velocity = new Vector2(-5f, rb.velocity.y);
    }
}
