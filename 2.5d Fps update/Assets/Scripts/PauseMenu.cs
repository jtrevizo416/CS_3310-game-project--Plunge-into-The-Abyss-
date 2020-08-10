using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject weaponHolder;
    public GameObject ammoBox;
    public GameObject healthBar;
    public GameObject crosshair;
    public GameObject pauseMenu;
    public static bool isntPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public bool getPauseState()
    {
        return isntPaused;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();

            if (isntPaused) //game is not paused
            {
                LockCursor();
                ResumeGame();
                
            }
            else // game is paused
            {
                PauseGame();
                UnlockCursor();
            }
        }
    }
    public void PauseGame()
    {
        Debug.Log("PauseGame function");
        weaponHolder.SetActive(false);
        healthBar.SetActive(false);
        crosshair.SetActive(false);
        ammoBox.SetActive(false);
        pauseMenu.SetActive(true);
        

        Time.timeScale = 0f;
        isntPaused = true;
        
    }
    public void ResumeGame()
    {
        Debug.Log("ResumeGame function");
        weaponHolder.SetActive(true);
        healthBar.SetActive(true);
        crosshair.SetActive(true);
        ammoBox.SetActive(true);
        pauseMenu.SetActive(false);
       
        Time.timeScale = 1f;
        isntPaused = false;
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