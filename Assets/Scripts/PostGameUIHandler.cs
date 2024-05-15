using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostGameUIHandler : MonoBehaviour
{
    [SerializeField] Button retryButton;

    
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