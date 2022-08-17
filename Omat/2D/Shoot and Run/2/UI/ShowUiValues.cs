using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUiValues : MonoBehaviour
{

    [SerializeField]
    private Text healtText;
    [SerializeField]
    private Text livesText;
    [SerializeField]
    private Text coinsText;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private PlayerInventory playerInventory;
    [SerializeField]

    private Timer timer;
    [SerializeField]
    private Timer2 timer2;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highscoreText;
    [SerializeField]
    private ScoreManager scoreManager;



    void Start()
    {
        
    }

    void Update()
    {
        healtText.text = "Health: " + playerHealth.health.ToString();
        livesText.text = "Lives: " + playerHealth.lives.ToString();
        coinsText.text = "Coins: " + playerInventory.coinCount.ToString();
        timerText.text = "Timer: " + timer2.timeText1.ToString();
        scoreText.text = "Points: " + scoreManager.score.ToString();
        highscoreText.text = "HIGHSCORE: " + scoreManager.highscore.ToString();

    }
}
