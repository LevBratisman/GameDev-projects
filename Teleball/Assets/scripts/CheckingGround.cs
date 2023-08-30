using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingGround : MonoBehaviour
{

    public Animator anim;
    public bool onGround;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "ground") {
            onGround = true;
            anim.SetBool("isRunning", true);
            anim.SetBool("isFlying", false);
        } else {
            anim.SetBool("isRunning", false);
            anim.SetBool("isFlying", true);
        }
    }

}
