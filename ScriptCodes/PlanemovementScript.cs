using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanemovementScript : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;      // speed of movement
    public float moveDistance = 5f;   // how far left and right to move
    public float waitTime = 3f;       // wait time at each edge

    private Vector3 startPos;
    private bool movingRight = true;
    private float waitTimer = 0f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (waitTimer > 0f)
        {
            waitTimer -= Time.deltaTime;
            return;
        }

        float step = moveSpeed * Time.deltaTime;

        if (movingRight)
        {
            transform.position += Vector3.right * step;
            if (transform.position.x >= startPos.x + moveDistance)
            {
                movingRight = false;
                waitTimer = waitTime;
            }
        }
        else
        {
            transform.position += Vector3.left * step;
            if (transform.position.x <= startPos.x - moveDistance)
            {
                movingRight = true;
                waitTimer = waitTime;
            }
        }
    }
}
