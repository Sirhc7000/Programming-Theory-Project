using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpeedSettings
{
    Speed1 = 0,
    Speed2 = 2,
    Speed3 = 4,
    Speed4 = 6,
    Speed5 = 8
}

public class GameManager : MonoBehaviour
{
    Timer timer;
    Mole mole;

    public SpeedSettings currentGameSpeed;
    bool isGameActive = true;

    const float Speed1Threshold = 80f;
    const float Speed2Threshold = 60f;
    const float Speed3Threshold = 40f;
    const float Speed4Threshold = 20f;
    const float Speed5Threshold = 0f;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        mole = FindObjectOfType<Mole>();

        isGameActive = true;
        ResumeGame();
        currentGameSpeed = SpeedSettings.Speed1;
    }

    void Update()
    {
        UpdateGameSpeed();
        CheckForExpiredTimer();
        
    }

    void UpdateGameSpeed()
    {

        float percentageRemaining = timer.timeRemainingPercentage;

        // this switch statement below uses the percentage of time remaining to
        // update the SpeedSettings. if the percentage is larger than the threshold,
        // this switch statement will set the currentGameSpeed state accordingly.
        // This also uses pattern matching which is new in C# 7.0. 
        switch (percentageRemaining)
        {
            // The variable 'p' takes on the value of percentage.
            case float p when p > Speed1Threshold:
                currentGameSpeed = SpeedSettings.Speed1;
                break;
            case float p when p > Speed2Threshold:
                currentGameSpeed = SpeedSettings.Speed2;
                break;
            case float p when p > Speed3Threshold:
                currentGameSpeed = SpeedSettings.Speed3;
                break;
            case float p when p > Speed4Threshold:
                currentGameSpeed = SpeedSettings.Speed4;
                break;
            case float p when p > Speed5Threshold:
                currentGameSpeed = SpeedSettings.Speed5;
                break;
        }

    }

    public bool IsGameActive()
    {
        return isGameActive;
    }

    public void EndGame()
    {
        isGameActive = false;
    }

    public void CheckForExpiredTimer()
    {
        if (timer.timeValue <= 0)
        {
            EndGame();
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
