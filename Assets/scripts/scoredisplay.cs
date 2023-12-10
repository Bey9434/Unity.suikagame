using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoredisplay : MonoBehaviour
{
     [SerializeField]
    private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        ScoreManager.OnScoreUpdated += UpdateScoreDisplay;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreUpdated -= UpdateScoreDisplay;
    }

    private void UpdateScoreDisplay(int newScore)
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score: " + newScore.ToString();
        }
    }
}
