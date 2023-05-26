using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainSceneUI : MonoBehaviour
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
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        _livesText = GameObject.Find("LivesText").GetComponent<TextMeshProUGUI>();
    }

    private string GetFormatText(string header, int value)
    {
        return string.Format("{0}: {1}", header, value);
    }
}
