using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int redBalloonsRequired = 1; // Number of balloons needed to progress
    private int redBalloonsPopped = 0;

    public void BalloonPopped(string tag)
    {
        if (tag == "RedBalloon")
        {
            Debug.Log("Red Balloon Popped");
            redBalloonsPopped++;
            CheckLevelProgress();
        }
    }

    void CheckLevelProgress()
    {
        if (redBalloonsPopped >= redBalloonsRequired)
        {
            Debug.Log("All required balloons popped! Loading next level...");
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // Load the next scene or go to Main Menu if on the last level
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels. Returning to Main Menu.");
            // No more levels, go to Main Menu
            SceneManager.LoadScene("Main Menu");
        }
    }
}
