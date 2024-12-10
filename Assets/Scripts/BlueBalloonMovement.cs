using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBalloonMovement : MonoBehaviour
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
        // Move up and down
        transform.Translate(Vector3.up * direction * speed * Time.deltaTime);

        // Reverse direction when reaching the distance
        if (Mathf.Abs(transform.position.y - startPosition.y) >= distance)
        {
            direction *= -1;
        }
    }
}