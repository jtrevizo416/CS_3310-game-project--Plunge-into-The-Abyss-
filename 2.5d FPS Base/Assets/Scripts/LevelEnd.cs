using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    public GameObject levelEndMenu;
    public Text KillsValue,timer;
    public float finaltime = 0.0f;
    public static bool isEnded = false;

    void Start()
    {
        levelEndMenu.SetActive(false);
    }
    private void Update()
    {
        
        if (PlayerController.instance.transform.position.x < -20 && PlayerController.instance.transform.position.x > -33 && PlayerController.instance.transform.position.y > 75 && PlayerController.instance.transform.position.y < 102)
        {
            isEnded = true;
            KillsValue.GetComponent<UnityEngine.UI.Text>().text = EnemyController.enemykills.ToString();
            timer.GetComponent<UnityEngine.UI.Text>().text = PlayerController.time.ToString("F2");
            UnlockCursor();
            levelEndMenu.SetActive(true);
            
        }
        
    }
    public void QuitGame()
    {
        Debug.Log("QuitGame function");

        Application.Quit(); //"The Application.Quit call is ignored in the Editor." <- from the documentation
    }
    public void RetryLevel()
    {
        LockCursor();
        Application.LoadLevel(Application.loadedLevel);
        EnemyController.enemykills = 0;
    }
    public void GoToMainMenu()
    {
        LockCursor();
        Application.LoadLevel(0);
        
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
