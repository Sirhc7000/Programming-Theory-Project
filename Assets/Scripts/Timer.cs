using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float startingTimeValue = 30f;
    public float timeValue;
    // public float currentTimeRemaining;
    public float timeRemainingPercentage;


    void Start()
    {
        timeValue = startingTimeValue;
    }

    // Update is called once per frame
    void Update()
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

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        // ensures all 30 seconds are displayed when timer reaches 0.
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        //converting seconds to min:seconds format ensuring 60 seconds will display 1:00
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void CalculateTimeValuePercentage()
    {
        timeRemainingPercentage = (timeValue / startingTimeValue) * 100;
    }
}