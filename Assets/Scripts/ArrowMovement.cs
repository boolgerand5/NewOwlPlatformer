using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] public float speed = 10f;

    void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        // Move the arrow to the right
        transform.Translate(movementSpeed, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check for balloons and destroy them on collision
        if (other.CompareTag("RedBalloon") || other.CompareTag("BlueBalloon"))
        {
            Destroy(other.gameObject); // Destroy the balloon
            Destroy(gameObject);       // Destroy the arrow
            
        }
    }
}