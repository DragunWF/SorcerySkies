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

    private MainSceneUI _mainSceneUI;
    private DifficultyScaling _difficultyScaling;
    private static GameState _instance;

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
        _difficultyLevel = 1;
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
        _mainSceneUI.UpdateScoreText(_score);
    }

    private void Awake()
    {
        ManageSingleton();
    }

    private void Start()
    {
        _mainSceneUI = FindObjectOfType<MainSceneUI>();
        _difficultyScaling = FindObjectOfType<DifficultyScaling>();

        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            StartCoroutine(GainScoreOverTime());
        }
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
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
