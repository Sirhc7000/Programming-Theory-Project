using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public Texture2D defaultCursor;
    public Texture2D clickedCursor;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public AudioClip hammerHit;
    public AudioClip hammerWhiff;

    GameManager gameManager;
    AudioSource audioSource;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        UpdateCursor();
    }

    public void UpdateCursor()
    {
        if (gameManager.isGameActive)
        {

            if (Input.GetMouseButtonUp(0))
            {
                Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Cursor.SetCursor(clickedCursor, hotSpot, cursorMode);
                PlayHammerSFX();
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

    void PlayHammerSFX()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Mole"))
            {
                audioSource.PlayOneShot(hammerHit, 0.5f);
            }
            else
            {
                audioSource.PlayOneShot(hammerWhiff);
            }
        }
    }
}

