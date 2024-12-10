using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private AudioSource audioSource;

    void Start()
    {
        // transform.right tells the rigidbody (arrow) to move right and then * speed tells it what speed and direction to go in.
        rb.velocity = transform.right * speed;
        audioSource = GetComponent<AudioSource>();
    }

    // This allows for functionality once the arrow hits something.
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check for balloons and destroy them on collision
        if (other.CompareTag("RedBalloon") || other.CompareTag("BlueBalloon"))
        {

            // We get the points from the BalloonBehavior script for when the balloon was popped.
            BalloonBehavior balloon = other.GetComponent<BalloonBehavior>();
            float points = balloon.GetPoints();

            

            // If a red balloon was popped, we add points
            if (other.CompareTag("RedBalloon"))
            {
                // Notify Level Manager that a red balloon was popped
                Debug.Log("Level Manager has been notified");
                FindObjectOfType<LevelManager>().BalloonPopped("RedBalloon");
                ScoreManager.instance.AddPoint(points);
            }
            // If a blue balloon was popped we remove points
            else
            {
                ScoreManager.instance.RemovePoint(points);
            }
            FindObjectOfType<AudioManager>().Play("BalloonPop");
            
            Destroy(other.gameObject); // Destroy the balloon
            Destroy(gameObject);       // Destroy the arrow
            
        }
    }

}
