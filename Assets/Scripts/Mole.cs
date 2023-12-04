using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Mole : MonoBehaviour
{
    public float playTime;
    public List<float> playTimeRangeValues;
    [SerializeField] int pointValue;

    Timer timer;
    GameManager gameManager;
    Score score;
    Animator animator;
   
    //Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        gameManager = FindObjectOfType<GameManager>();
        score = FindObjectOfType<Score>();
        animator = GetComponent<Animator>();

        UpdatePlayTimeBySpeedSetting(gameManager.currentGameSpeed);
        animator.SetTrigger("OnMoleSpawn");
    }

    private void Update()
    {
        CountDownPlayTime();

        if (playTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.IsGameActive())
        {
            score.AddToScore(pointValue);
            Destroy(gameObject);
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

    
}
