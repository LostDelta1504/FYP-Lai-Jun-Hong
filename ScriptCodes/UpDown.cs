using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
   [Header("Movement Settings")]
    public float moveHeight = 5f;      // How high to go
    public float upDuration = 0.5f;    // Fast up
    public float downDuration = 2f;    // Slow down
    public bool loop = true;

    private Vector3 bottomPos;
    private Vector3 topPos;
    private float timer = 0f;
    private bool goingUp = true;

    void Start()
    {
        bottomPos = transform.position;
        topPos = bottomPos + Vector3.up * moveHeight;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (goingUp)
        {
            float t = timer / upDuration;
            transform.position = Vector3.Lerp(bottomPos, topPos, t);

            if (t >= 1f)
            {
                // Switch to going down
                timer = 0f;
                goingUp = false;
            }
        }
        else
        {
            float t = timer / downDuration;
            transform.position = Vector3.Lerp(topPos, bottomPos, t);

            if (t >= 1f)
            {
                if (loop)
                {
                    // Switch back to going up
                    timer = 0f;
                    goingUp = true;
                }
                else
                {
                    enabled = false; // stop when done
                }
            }
        }
    }
}
