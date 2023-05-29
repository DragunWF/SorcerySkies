using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class RetryMenuUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highScoreText;
    private TextMeshProUGUI newHighScoreText;
    private GameState gameState;

    private void Awake()
    {
        scoreText = Utils.GetTextObj("ScoreText");
        highScoreText = Utils.GetTextObj("HighScoreText");
        newHighScoreText = Utils.GetTextObj("NewHighScoreText");
        gameState = FindObjectOfType<GameState>();
    }

    private void Start()
    {
        scoreText.text = string.Format("Score: {0}",
                                       Utils.FormatNumber(gameState.GetScore()));
        highScoreText.text = string.Format("High Score: {0}",
                                           Utils.FormatNumber(gameState.GetHighScore()));
        newHighScoreText.gameObject.SetActive(gameState.IsNewHighScore());
    }
}
