using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {
    Text statistics;

	void Awake () {
        statistics = GameObject.Find("Statistics").GetComponent<Text>();
        if (statistics != null)
        {
            statistics.text = "Enemies Slain: " + PlayerPrefs.GetInt("Slain").ToString() + "    Level: " + PlayerPrefs.GetInt("Level").ToString();
        }
	}	    
}
