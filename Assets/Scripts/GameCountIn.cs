using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCountIn : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    [SerializeField] AudioClip countdownBeep;
    [SerializeField] AudioClip countdownGo;

    private bool _condition;

    AudioSource audioSource;

    IEnumerator Start()
    {
        audioSource = GetComponent<AudioSource>();

        while (_condition)
        {
            yield return null;
        }

        Time.timeScale = 0;
        for (int i = 3; i >= 0; i--)
        {
            if (i > 0)
            {
                countdownText.text = i.ToString();
                audioSource.clip = countdownBeep;
                audioSource.Play();
            }
            else
            {
                countdownText.text = "GO!";
                audioSource.clip = countdownGo;
                audioSource.Play();

            }

            yield return new WaitForSecondsRealtime(1);
        }
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
