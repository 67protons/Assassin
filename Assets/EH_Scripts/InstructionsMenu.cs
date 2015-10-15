using UnityEngine;
using System.Collections;

public class InstructionsMenu : MonoBehaviour {
    bool isActive = false;
    GameObject instructionsPanel;

    void Start()
    {
        instructionsPanel = GameObject.Find("InstructionsPanel");
        instructionsPanel.SetActive(false);
    }

    public void Activate()
    {
        instructionsPanel.SetActive(true);
    }

    public void Deactivate()
    {
        instructionsPanel.SetActive(false);
    }
}
