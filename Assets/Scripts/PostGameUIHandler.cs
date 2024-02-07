using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostGameUIHandler : MonoBehaviour
{
    [SerializeField] Button retryButton;

    // Start is called before the first frame update
    public void ActivateButton()
    {
        retryButton.interactable = false;
        StartCoroutine(WaitAndSetInteractable());
    }

    IEnumerator WaitAndSetInteractable()
    {
        yield return new WaitForSecondsRealtime(1);
        retryButton.interactable = true;
    }
}