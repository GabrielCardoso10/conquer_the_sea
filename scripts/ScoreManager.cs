using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0; 
    private int highScore = 0;   
    public TextMeshProUGUI scoreText;  
    public TextMeshProUGUI highScoreText; 

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }

    public void GameOver()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            if (highScoreText != null)
            {
                highScoreText.text = "High Score: " + highScore.ToString();
            }
        }
    }

    public void AddScore(int value)
    {
        currentScore += value;
    }

    public int GetHighScore()
    {
        return highScore;
    }
}
