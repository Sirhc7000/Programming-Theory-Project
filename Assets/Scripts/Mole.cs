using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Mole : MonoBehaviour
{
    public float playTime;
    public List<float> playTimeRangeValues;

    Timer timer;

   
    //Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void SetPlayTime(float value1, float value2)
    {
        playTime = Random.Range(value1, value2);
    }

    // TODO: Figure below out next. How can I make this work with parameters?
    private void UpdatePlayTimeBySpeedSetting(SpeedSettings setting, int index)
    {
       SetPlayTime(playTimeRangeValues[index], playTimeRangeValues[index + 1]);
        
    }
    
}
