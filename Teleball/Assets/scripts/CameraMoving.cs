using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{

    public Vector2 offset = new Vector2(2f, 1f);
    private Transform player;
    private int lastX;
    public float dumping = 0.1f;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer();
    }

    void Update()
    {
        if (player) {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) {
                lastX = Mathf.RoundToInt(player.position.x);
            }

            Vector3 target;
            target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, -10f);

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }

    void FindPlayer() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, -10f);
    }

}
