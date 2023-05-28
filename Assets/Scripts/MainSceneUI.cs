using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class MainSceneUI : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _livesText;

    public void UpdateScoreText(int value)
    {
        _scoreText.text = GetFormatText("Score", value);
    }

    public void UpdateLivesText(int value)
    {
        _livesText.text = GetFormatText("Lives", value);
    }

    private void Awake()
    {
        _scoreText = Utils.GetTextObj("ScoreText");
        _livesText = Utils.GetTextObj("LivesText");
    }

    private string GetFormatText(string header, int value)
    {
        return string.Format("{0}: {1}", header, value);
    }
}
