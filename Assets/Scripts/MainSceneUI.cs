using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainSceneUI : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _livesText;

    private void Awake()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        _livesText = GameObject.Find("LivesText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {

    }
}
