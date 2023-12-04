using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> moles;
    public List<float> spawnDelayRangeValues;
    public float spawnDelay;
    private float timeSinceLastSpawn = 0f;

    Timer timer;
    GameManager gameManager;
    //Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        gameManager = FindObjectOfType<GameManager>();
        //animator = GetComponent<Animator>();

        UpdateSpawnDelayBySpeedSetting(gameManager.currentGameSpeed);
       
    }

    // Update is called once per frame
    void Update()
    {
        // if there is no mole spawned, start timeSinceLastSpawn timer.
        // once the mole is generated in this script, this will not run again until the mole is destroyed. 
        if (transform.childCount < 1)
        {
            timeSinceLastSpawn += Time.deltaTime;

            // if timeSinceLastSpawn hits spawnDelay time, reset timer, update the spawn delay speed based on how much time is left, and generate the mole. 
            if (timeSinceLastSpawn >= spawnDelay)
            {
                timeSinceLastSpawn = 0f;
                UpdateSpawnDelayBySpeedSetting(gameManager.currentGameSpeed);
                GenerateMole();
                //animator.SetTrigger("OnMoleSpawn");
            }

        }
        
    }

    private void GenerateMole()
    {
        int randomMole = Random.Range(0, moles.Count);
        GameObject newMole = Instantiate(moles[randomMole],
            new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.Euler(0f, 180f, 0f), this.transform);
    }

    private void SetDelayTime(float value1, float value2)
    {
        spawnDelay = Random.Range(value1, value2);
    }

    private void UpdateSpawnDelayBySpeedSetting(SpeedSettings setting)
    {
        int index = (int)setting;
        SetDelayTime(spawnDelayRangeValues[index], spawnDelayRangeValues[index + 1]);
    }

}
