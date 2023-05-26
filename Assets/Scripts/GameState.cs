using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private int _score = 0;
    private int _difficultyLevel = 1;
    private MainSceneUI mainSceneUI;

    public int getScore() => _score;
    public int getDifficultyLevel() => _difficultyLevel;

    public void IncreaseScore(int addition)
    {
        _score += addition;
        mainSceneUI.UpdateScoreText(_score);
    }

    private void Awake()
    {
        mainSceneUI = FindObjectOfType<MainSceneUI>();
    }
}
