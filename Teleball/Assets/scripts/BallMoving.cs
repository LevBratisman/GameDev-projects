using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallMoving : MonoBehaviour
{

    public Rigidbody2D rb;
    float Speed = 5f;
    public Animator anim;
    bool isRunning = false;
    bool isTop = false;
    public GameObject panel;
    public GameObject panelFinish;
    public Scene menu;
    public bool onGround;
    public GameObject effect;
    public int sceneIndex;
    public GameObject text;
    public GameObject cursorHider;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        isRunning = true;
        anim.SetBool("isRunning", true);
        if (isRunning) {
            StartRunning();
            ChangeGravity();
        }
    }

    void StartRunning() {
        rb.velocity = new Vector2(5f, rb.velocity.y);
    }

    void ChangeGravity() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.gravityScale *= -1;
            isTop = !isTop;
            anim.SetBool("isFlying", true);
            anim.SetBool("isRunning", false);
            text.SetActive(false);
        }
        if (isTop) {
            transform.eulerAngles = new Vector3 (0, 0, -180);
            transform.localScale = new Vector3(-5, transform.localScale.y, 1);
        } else if (!isTop) {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(5, transform.localScale.y, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "trap") {
            Cursor.visible = true;
            Destroy(gameObject);
            panel.SetActive(true);
            Instantiate(effect, transform.position, Quaternion.identity);
            text.SetActive(false);
        }
        if (other.gameObject.tag == "crown") {
            Cursor.visible = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
            panelFinish.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Finish") {
            Cursor.visible = true;
            panelFinish.SetActive(true);
            PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "crown") {
            Cursor.visible = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
            panelFinish.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "trap") {
            Cursor.visible = true;
            Destroy(gameObject);
            panel.SetActive(true);
            Instantiate(effect, transform.position, Quaternion.identity);
            text.SetActive(false);
        }
    }

}
