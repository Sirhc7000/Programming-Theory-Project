using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image fadeOutUIImage;
    public float fadeSpeed = 0.8f;
    public string sceneToLoad;

    public void FadeAndLoadScene()
    {
        StartCoroutine(FadeAndSwitchScenes(sceneToLoad));
    }

    private IEnumerator FadeAndSwitchScenes(string sceneName)
    {
        yield return StartCoroutine(FadeToBlack());
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeToBlack()
    {
        fadeOutUIImage.gameObject.SetActive(true);
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, 0);
        float alphaValue = 0;
        while (alphaValue < 1)
        {
            alphaValue += Time.deltaTime / fadeSpeed;
            fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alphaValue);
            yield return null;
        }
    }
}
