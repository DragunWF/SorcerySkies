using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameState : MonoBehaviour
{
    private int _score = 0;
    private int _highScore = 0;
    private bool _newHighScore = false;
    private int _difficultyLevel = 1;
    private bool isPlayerAlive = true;

    private MainSceneUI mainSceneUI;
    private DifficultyScaling difficultyScaling;
    private static GameState instance;

    #region Getter Methods

    public int getScore() => _score;
    public int getHighScore() => _highScore;
    public int getDifficultyLevel() => _difficultyLevel;
    public bool isNewHighScore() => _newHighScore;

    #endregion

    public void IncreaseDifficulty()
    {
        _difficultyLevel++;
    }

    public void StopScore()
    {
        isPlayerAlive = false;
    }

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
        ManageSingleton();
        mainSceneUI = FindObjectOfType<MainSceneUI>();
        difficultyScaling = FindObjectOfType<DifficultyScaling>();
    }

    private void Start()
    {
        StartCoroutine(GainScoreOverTime());
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private IEnumerator GainScoreOverTime()
    {
        const float delay = 0.5f;
        yield return new WaitForSeconds(delay);

        const int scoreGainPerInterval = 1;
        const float secondsPerPoint = 1;
        while (isPlayerAlive)
        {
            IncreaseScore(scoreGainPerInterval);
            yield return new WaitForSeconds(secondsPerPoint);
        }
    }
}
