using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameState : MonoBehaviour
{
    private int _score = 0;
    private int _highScore = 0;
    private bool _newHighScore = false;
    private int _difficultyLevel = 0;

    private MainSceneUI _mainSceneUI;
    private DifficultyScaling _difficultyScaling;
    private static GameState _instance;

    #region Getter Methods

    public int GetScore() => _score;
    public int GetHighScore() => _highScore;
    public int GetDifficultyLevel() => _difficultyLevel;
    public bool IsNewHighScore() => _newHighScore;

    #endregion

    public void IncreaseDifficulty()
    {
        _difficultyLevel++;
    }

    public void StopScore()
    {
        StopAllCoroutines();
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
        _mainSceneUI.UpdateScoreText(_score);
    }

    public void StartState()
    {
        _mainSceneUI = FindObjectOfType<MainSceneUI>();
        _difficultyScaling = FindObjectOfType<DifficultyScaling>();

        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            StartCoroutine(GainScoreOverTime());
        }
    }

    private void Awake()
    {
        ManageSingleton();
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
        while (true)
        {
            IncreaseScore(scoreGainPerInterval);
            yield return new WaitForSeconds(secondsPerPoint);
        }
    }
}
