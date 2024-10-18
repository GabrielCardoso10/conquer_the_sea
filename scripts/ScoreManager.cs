using UnityEngine;
using TMPro;  // Para exibir na UI, se você estiver usando TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;  // Pontuação atual do jogador
    private int highScore = 0;    // Recorde salvo
    public TextMeshProUGUI scoreText;  // Exibir pontuação na UI (opcional)
    public TextMeshProUGUI highScoreText;  // Exibir recorde na UI (opcional)

    void Start()
    {
        // Carrega o recorde salvo quando o jogo inicia
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Atualiza o texto do recorde na UI, se houver
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    void Update()
    {
        // Atualiza o texto da pontuação na UI durante o jogo
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }

    // Função chamada quando o jogo termina
    public void GameOver()
    {
        // Se a pontuação atual for maior que o recorde, salva o novo recorde
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();  // Salva os dados no dispositivo

            // Atualiza o texto do recorde na UI
            if (highScoreText != null)
            {
                highScoreText.text = "High Score: " + highScore.ToString();
            }
        }
    }

    // Função para adicionar pontuação (chame essa função para adicionar pontos)
    public void AddScore(int value)
    {
        currentScore += value;
    }

    // Função para obter o recorde atual (se precisar exibir em outra parte do jogo)
    public int GetHighScore()
    {
        return highScore;
    }
}
