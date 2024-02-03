using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif



public class StartMenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public GameObject startMenuData;

   

    private void Start()
    {
        startMenuData.GetComponent<StartMenuData>().LoadHighScore();
        SetHighScoreUI();

        print($"Score:{PlayerData.Instance.highScore}");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetHighScoreUI()
    {
        highScoreText.text = $"High Score: {PlayerData.Instance.highScore} Points";
    }

   
}
