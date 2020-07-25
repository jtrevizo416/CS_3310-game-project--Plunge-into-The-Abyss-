using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UnlockCursor();

            if (isPaused)
            {
                LockCursor();
                ResumeGame();
                
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        Debug.Log("PauseGame function");

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        
    }
    public void ResumeGame()
    {
        Debug.Log("ResumeGame function");

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        LockCursor();
    }
    public void GoToMainMenu() // Add later when main menu gets created
    {

    }
    public void QuitGame()
    {
        Debug.Log("QuitGame function");

        Application.Quit(); //"The Application.Quit call is ignored in the Editor." <- from the documentation
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