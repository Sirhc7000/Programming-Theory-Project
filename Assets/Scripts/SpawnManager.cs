using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> moles;
    [SerializeField] private List<DifficultySetting> difficultySettings;
    public float spawnDelay;
    private float timeSinceLastSpawn = 0f;

    Timer timer;
    GameManager gameManager;


    void Start()
    {
        timer = FindObjectOfType<Timer>();
        gameManager = FindObjectOfType<GameManager>();

        UpdateSpawnDelayBySpeedSetting(gameManager.currentGameSpeed);
       
    }

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

    private void UpdateSpawnDelayBySpeedSetting(SpeedSettings newSpeed)
    {
        foreach(DifficultySetting difficultySetting in difficultySettings)
        {
            if (difficultySetting.speedSetting == newSpeed)
            {
                spawnDelay = difficultySetting.GetSpawnDelay();
                break;
            }
        }
    }

}
