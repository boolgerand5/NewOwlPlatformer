using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBalloonMovement : MonoBehaviour
{
    public float speed = 2f; // Speed of movement
    public float distance = 3f; // Distance to move

    private Vector3 startPosition;
    private int direction = 1;

    void Start()
    {
        startPosition = transform.position; // Save the starting position
    }

    void Update()
    {
        // Move left and right
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // Reverse direction when reaching the distance
        if (Mathf.Abs(transform.position.x - startPosition.x) >= distance)
        {
            direction *= -1;
        }
    }
}