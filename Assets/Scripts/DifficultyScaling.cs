using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DifficultyScaling : MonoBehaviour
{
    private GameState _gameState;
    private Spawner _spawner;
    private float[] _difficulties = {
        2.25f, 1.75f, 1.25f, 1f, 0.75f,
        0.5f, 0.4f, 0.3f, 0.25f, 0.175f,
        0.15f, 0.125f, 0.1f, 0.0075f
    };
    private float _currentTimeToScale = 5;
    private float _currentDifficultyTime;

    #region Getter Methods

    public float GetCurrentDifficultyTime() => _currentDifficultyTime;

    #endregion

    private void Awake()
    {
        _gameState = FindObjectOfType<GameState>();
        _spawner = FindObjectOfType<Spawner>();
    }

    private void Start()
    {
        StartCoroutine(ScaleDifficulty());
    }

    private IEnumerator ScaleDifficulty()
    {
        const float delay = 0.5f;
        yield return new WaitForSeconds(delay);

        while (_gameState.GetDifficultyLevel() < _difficulties.Length)
        {
            int level = _gameState.GetDifficultyLevel();
            Debug.Log(string.Format("Difficulty Level: {0}", level));
            _gameState.IncreaseDifficulty();
            _spawner.UpdateSpawnSpeed(_difficulties[level]);

            if (level <= 4)
            {
                _currentTimeToScale++;
            }
            else if (level <= 8)
            {
                _currentTimeToScale += 2.5f;
            }
            else
            {
                _currentTimeToScale += 5.5f;
            }

            yield return new WaitForSeconds(_currentTimeToScale);
        }
    }
}
