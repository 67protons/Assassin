using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void PressPlay()
    {
        Cursor.visible = false;
        Application.LoadLevel("Game");
    }

    public void PressMainMenu()
    {
        Cursor.visible = true;
        Application.LoadLevel("Main Menu");
    }

    public void PressQuit()
    {
        Application.Quit();
    }
}
