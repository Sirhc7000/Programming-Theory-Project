using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    const float startingTimeValue = 30f;
    public float timeValue;
    // public float currentTimeRemaining;
    public float timeRemainingPercentage;

    GameManager gameManager;


    void Start()
    {
        timeValue = startingTimeValue;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameActive())
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;

            }

            // clamping the time to 0 if it goes below that to prevent negative values
            else
            {
                timeValue = 0;
            }
        
            DisplayTime(timeValue);
            CalculateTimeValuePercentage();

        }

    }

    void DisplayTime(float timeToDisplay)
    {
        // Ensure timeToDisplay never goes below 0 or above the set starting value
        timeToDisplay = Mathf.Max(0, timeToDisplay);

        // Calculate the display time as an integer
        int timeFloor = Mathf.FloorToInt(timeToDisplay);

        // Adjust for the rounding issue by checking the fractional part
        // This ensures we don't prematurely increment the displayed time
        if (timeToDisplay - timeFloor > 0)
        {
            timeFloor += 1;
        }

        // Update the text display
        timerText.text = timeFloor.ToString();
    }

    void CalculateTimeValuePercentage()
    {
        timeRemainingPercentage = (timeValue / startingTimeValue) * 100;
    }
}