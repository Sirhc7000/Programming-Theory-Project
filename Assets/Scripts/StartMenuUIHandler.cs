using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartMenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public GameObject startMenuData;
    public GameObject blackOutSquare;

   
    private void Start()
    {
        startMenuData.GetComponent<StartMenuData>().LoadHighScore();
        SetHighScoreUI();

        print($"Score:{PlayerData.Instance.highScore}");
    }

    //public void StartGame()
    //{
    //    StartCoroutine(StartGameSequence());
    //}

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    //public IEnumerator StartGameSequence()
    //{
    //    yield return StartCoroutine(FadeBlackOutSquare(true));
    //    yield return new WaitForSeconds(1);
    //    LoadMainScene();
    //}

    public void SetHighScoreUI()
    {
        highScoreText.text = $"High Score: {PlayerData.Instance.highScore} Points";
    }

    //public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 5)
    //{
    //    Color objectColor = blackOutSquare.GetComponent<Image>().color;
    //    float fadeAmount;

    //    if (fadeToBlack)
    //    {
    //        // Fade To Black
    //        while (blackOutSquare.GetComponent<Image>().color.a < 1)
    //        {
    //            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

    //            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
    //            blackOutSquare.GetComponent<Image>().color = objectColor;
    //            yield return null;
    //        }
    //    }
    //    else
    //    {
    //        // Fade From Black
    //        while (blackOutSquare.GetComponent<Image>().color.a > 0)
    //        {
    //            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

    //            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
    //            blackOutSquare.GetComponent<Image>().color = objectColor;
    //            yield return null;
    //        }
    //        blackOutSquare.SetActive(false);
    //    }
    //}


}
