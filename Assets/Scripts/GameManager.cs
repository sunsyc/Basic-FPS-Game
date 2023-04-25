using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gamePausedUI;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy || gamePausedUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                resume();
            }
            else
            {
                gamePaused();
            }
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void gamePaused()
    {
        gamePausedUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void resume()
    {
        gamePausedUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
