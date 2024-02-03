using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreTotalText;
    [SerializeField] int currentScore;

    PlayerData playerData;

    private void Awake()
    {
        LoadHighScore();
    }

    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
    }

    public void AddToScore(int scoreValue)
    {
        currentScore += scoreValue;

        if (currentScore <= 0)
        {
            currentScore = 0;
        }

        UpdateScoreDisplay();
    }

   void UpdateScoreDisplay()
   {
        scoreText.text = $"{currentScore}";
        scoreTotalText.text = $"{currentScore}";
   }

    public void UpdateHighScore()
    {
        print($"Previous: {playerData.highScore}");

        if (currentScore > playerData.highScore)
        {
            playerData.highScore = currentScore;
            SaveHighScore(playerData.highScore);
            print($"New: {playerData.highScore}");
        }


    }

    public void SaveHighScore(int highScore)
    {
        SaveData data = new SaveData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerData.Instance.highScore = data.highScore;

        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
    }
}
