using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Mole : MonoBehaviour
{
    public float playTime;
    public List<float> playTimeRangeValues;
    [SerializeField] int pointValue;
    float destroyDelay = 0.4f;

    
    [SerializeField] AudioClip moleAppear;
    [SerializeField] AudioClip moleHit;


    Timer timer;
    GameManager gameManager;
    Score score;
    Animator animator;
    AudioSource audioSource;

    //Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        gameManager = FindObjectOfType<GameManager>();
        score = FindObjectOfType<Score>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        UpdatePlayTimeBySpeedSetting(gameManager.currentGameSpeed);
        animator.SetTrigger("OnMoleSpawn");

        audioSource.clip = moleAppear;
        audioSource.Play();

    }

    private void Update()
    {
        CountDownPlayTime();

        if (playTime < 0)
        {
            MoleDown();
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.IsGameActive())
        {
            audioSource.clip = moleHit;
            audioSource.Play();

            score.AddToScore(pointValue);
            
            MoleDown();
        }
    }

    private void SetPlayTime(float value1, float value2)
    {
        playTime = Random.Range(value1, value2);
    }

    
    private void UpdatePlayTimeBySpeedSetting(SpeedSettings setting)
    {
        int index = (int)setting;
       SetPlayTime(playTimeRangeValues[index], playTimeRangeValues[index + 1]);
        
    }


    private void CountDownPlayTime()
    {
        playTime -= Time.deltaTime;
    }

    private void MoleDown()
    {
        animator.SetTrigger("OnMoleExpired");
        Destroy(gameObject, destroyDelay);
    }

    
}
