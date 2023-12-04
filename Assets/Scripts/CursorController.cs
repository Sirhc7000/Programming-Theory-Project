using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public Texture2D defaultCursor;
    public Texture2D clickedCursor;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}
