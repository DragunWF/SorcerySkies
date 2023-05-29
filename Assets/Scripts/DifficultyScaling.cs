using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DifficultyScaling : MonoBehaviour
{
    private GameState _gameState;
    private Spawner _spawner;
    private float[] _difficulties = {
        2.25f, 1.75f, 1.25f, 1f, 0.75f, 0.5f, 0.4f, 0.3f, 0.25f, 0.175f
    };
    private float _currentTimeToScale = 3;
    private float _currentDifficultyTime;

    #region Getter Methods

    public float GetCurrentDifficultyTime() => _currentDifficultyTime;

    #endregion

    private void Awake()
    {
        _gameState = FindObjectOfType<GameState>();
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
            Debug.Log(string.Format("Difficulty Level: {0}", _gameState.GetDifficultyLevel()));
            yield return new WaitForSeconds(_currentTimeToScale);
            _gameState.IncreaseDifficulty();
            _spawner.UpdateSpawnSpeed(_difficulties[_gameState.GetDifficultyLevel()]);
            _currentTimeToScale++;
        }
    }
}
