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
                                       Utils.FormatNumber(gameState.getScore()));
        highScoreText.text = string.Format("High Score: {0}",
                                           Utils.FormatNumber(gameState.getHighScore()));
        if (gameState.isNewHighScore())
        {
            // show the new high score text
        }
    }
}
