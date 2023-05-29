using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DifficultyScaling : MonoBehaviour
{
    private GameState _gameState;
    private Spawner _spawner;
    private float[] _difficulties = {
        2.25f, 2f, 1.75f, 1.5f, 1.25f, 1f, 0.75f, 0.5f, 0.4f, 0.3f, 0.25f
    };
    private float _currentTimeToScale;

    private void Awake()
    {
        _currentTimeToScale = _difficulties[0];
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

        while (true)
        {
            _gameState.increaseDifficulty();
            yield return new WaitForSeconds(_currentTimeToScale);
        }
    }
}
