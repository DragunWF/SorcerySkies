using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameState : MonoBehaviour
{
    private int _score = 0;
    private int _highScore = 0;
    private bool _newHighScore = false;
    private int _difficultyLevel = 1;
    private MainSceneUI mainSceneUI;

    public int getScore() => _score;
    public int getHighScore() => _highScore;
    public int getDifficultyLevel() => _difficultyLevel;
    public bool isNewHighScore() => _newHighScore;

    public void ResetState()
    {
        _score = 0;
        _difficultyLevel = 0;
        _newHighScore = false;
    }

    public void SaveScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            _newHighScore = true;
        }
    }

    public void IncreaseScore(int addition)
    {
        _score += addition;
        mainSceneUI.UpdateScoreText(_score);
    }

    private void Awake()
    {
        mainSceneUI = FindObjectOfType<MainSceneUI>();
    }

    private void Start()
    {
        StartCoroutine(GainScoreOverTime());
    }

    private IEnumerator GainScoreOverTime()
    {
        const float delay = 0.5f;
        yield return new WaitForSeconds(delay);

        const int scoreGainPerInterval = 1;
        const float secondsPerPoint = 1;
        while (true)
        {
            IncreaseScore(scoreGainPerInterval);
            yield return new WaitForSeconds(secondsPerPoint);
        }
    }
}
