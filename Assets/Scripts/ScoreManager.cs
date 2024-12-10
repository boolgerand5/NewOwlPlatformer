using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highscoreText;

    float score = 0;
    float highscore = 0;

    // Before even the start of the game we get a reference to the score manager. 
    // We need this so when we handle the balloon and arrow collisions we can refer to something in order to change the score.
    void Awake() {
        instance = this;
    } 

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint(float points) {
        Debug.Log("In AddPoint");
        score += points;
        scoreText.text = score.ToString() + " POINTS";
        if(highscore < score)
        {
            PlayerPrefs.SetFloat("highscore", score);
        }
        
    }

    public void RemovePoint(float points) {
        Debug.Log("In RemovePoint");
        score -= points;
        scoreText.text = score.ToString() + " POINTS";
        if(highscore < score)
        {
            PlayerPrefs.SetFloat("highscore", score);
        }
    }
    
}
