using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostMoving : MonoBehaviour
{

    public Rigidbody2D rb;
    float Speed = 5f;
    public SpriteRenderer sr;


    void Start()
    {
        StartCoroutine ("moving");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void flip()
    {
        sr.flipX = !sr.flipX;
    }

    IEnumerator moving()
    {
        while (true) {
            flip();
            rb.velocity = new Vector2(1f, rb.velocity.y);
            yield return new WaitForSeconds (4f);
            flip();
            rb.velocity = new Vector2(-1f, rb.velocity.y);
            yield return new WaitForSeconds (4f);
        }
    }

}
