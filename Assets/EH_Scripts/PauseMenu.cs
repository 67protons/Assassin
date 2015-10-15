using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    GameObject pauseMenuPanel;
    bool isPaused = false;
    GameObject player;


    void Start()
    {
        pauseMenuPanel = GameObject.Find("PauseMenu");
        player = GameObject.Find("Player");
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            UnpauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        pauseMenuPanel.SetActive(true);
        player.GetComponent<PlayerLeftClick>().enabled = false;
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        pauseMenuPanel.SetActive(false);
        player.GetComponent<PlayerLeftClick>().enabled = true;
    }
}
