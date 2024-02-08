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
    public float timeRemainingPercentage;

    [SerializeField] AudioClip beep;
    [SerializeField] AudioClip horn;

    GameManager gameManager;
    AudioSource audioSource;

    private float lastBeepTime = 0f;
    private float startBeepTime = 3f;

    const int MAX_BEEPS = 3;
    int currentBeeps = 0;

    void Start()
    {
        timeValue = startingTimeValue;
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameActive())
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;

                // Play beep sound for the last 3 seconds, once per second
                if (timeValue <= startBeepTime &&
                    Mathf.FloorToInt(timeValue) != lastBeepTime &&
                    currentBeeps < MAX_BEEPS)
                {
                    lastBeepTime = Mathf.FloorToInt(timeValue);
                    audioSource.PlayOneShot(beep, 0.5f);
                    currentBeeps++;
                }
            }
            if (timeValue <= 0)
            {
                timeValue = 0;
                audioSource.PlayOneShot(horn, 0.75f);
            }

            DisplayTime(timeValue);
            CalculateTimeValuePercentage();

        }

    }

    void DisplayTime(float timeToDisplay)
    {
        // Ensure timeToDisplay never goes below 0 or above the current set timeValue
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