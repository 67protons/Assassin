using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static int level = 0;
    public static int slain = 0;
    private int slainLastLevel = 0;    
    Text statistics;    

    AudioSource source;    
    public AudioClip easy;
    public AudioClip medium;
    public AudioClip hard;

    void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            Player.health = 4;
            GameManager.level = 1;
            GameManager.slain = 0;
        }
    }

    void Awake()
    {        
        source = GetComponent<AudioSource>();
        statistics = GameObject.Find("Statistics").GetComponent<Text>();                
    }

    void Update()
    {
        statistics.text = "Enemies Slain: " + slain.ToString() + "   Level: " + level.ToString();
        LevelUp();
        GameOver();
    }

    void LevelUp()
    {
        if (GameManager.slain - slainLastLevel >= level)
        {
            slainLastLevel += level;
            level += 1;
            if (level >= 10 && level < 20 && source.clip != medium)
            {
                int time = source.timeSamples;                
                source.clip = medium;                
                source.timeSamples = time;
                source.Play();
            }
            else if (level >= 20 && source.clip != hard)
            {
                int time = source.timeSamples;
                source.clip = hard;
                source.timeSamples = time;
                source.Play();
            }
        }
    }

    void GameOver()
    {
        if (Player.health <= 0)
        {
            PlayerPrefs.SetInt("Slain", GameManager.slain);
            PlayerPrefs.SetInt("Level", GameManager.level);
            Cursor.visible = true;
            Application.LoadLevel("Game Over");
        }
    }
}
