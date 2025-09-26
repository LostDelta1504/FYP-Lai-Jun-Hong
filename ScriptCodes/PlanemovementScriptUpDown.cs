using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanemovementScriptUpDown : MonoBehaviour
{
[Header("Movement Settings")]
    public float moveSpeed = 2f;       // how fast it moves
    public float moveDistance = 3f;    // how far up and down

    private float startY;

    void Start()
    {
        // store starting Y position
        startY = transform.position.y;
    }

    void Update()
    {
        // PingPong returns a value that goes back and forth
        float newY = startY + Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
