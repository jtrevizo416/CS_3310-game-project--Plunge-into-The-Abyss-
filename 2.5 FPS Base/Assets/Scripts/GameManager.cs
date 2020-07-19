using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//if user presses escape key unlock the cursor
        {
            UnlockCursor();
        }

        if (Input.GetMouseButton(0))//if user clicks on window relock the cursor
        {
            LockCursor();
        }
    }

    private void LockCursor()//Lock cursor to window and make it dissapear when playing the game
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
