using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonBehavior : MonoBehaviour
{
    public float growthInterval = 0.5f; // How often the balloon grows (in seconds)
    public float growthAmount = 0.1f;  // How much the balloon grows each interval
    public float maxSize = 2f;         // The maximum scale before the balloon pops
    public float initialPoints = 100f; // Points when the balloon is smallest
    public float popPenalty = 10f;     // How many points are deducted as it grows

    private float currentPoints;       // Current points the balloon is worth

    void Start()
    {
        // Initialize the balloon size and points
        transform.localScale = Vector3.one * 0.5f; // Start small
        currentPoints = initialPoints;

        // Start the growth cycle
        InvokeRepeating(nameof(GrowBalloon), 0f, growthInterval);
    }

    void GrowBalloon()
    {
        // Increase the scale
        transform.localScale += Vector3.one * growthAmount;

        // Decrease the points as it grows
        currentPoints = Mathf.Max(0, currentPoints - popPenalty);

        // Check if the balloon has reached its maximum size
        if (transform.localScale.x >= maxSize || transform.localScale.y >= maxSize)
        {


            // Cancel further growth
            CancelInvoke(nameof(GrowBalloon));

            // Destroy the balloon since it popped on its own
            Destroy(gameObject);

            SceneManager.LoadScene("Main Menu");
        }
    }

    public float GetPoints()
    {
        return currentPoints;
    }
}