using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager intance;

    //public Text scoreText;
    //public Text highscoreText;

    public int score = 0;
    public int highscore = 0;

    private void Awake()
    {
        intance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        //scoreText.text = "POINTS: " + score.ToString();
        //highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        //scoreText.text = "POINTS: " + score.ToString();
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
        //Debug.Log(score);
        //Debug.Log(highscore);
    }
    
}
