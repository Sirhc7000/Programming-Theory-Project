using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreTotalText;
    [SerializeField] int scoreTotal;

    public void AddToScore(int scoreValue)
    {
        scoreTotal += scoreValue;

        if (scoreTotal <= 0)
        {
            scoreTotal = 0;
        }

        UpdateScoreDisplay();
    }

   void UpdateScoreDisplay()
    {
        scoreText.text = $"Score: {scoreTotal}";
        scoreTotalText.text = $"{scoreTotal}";
    }
}