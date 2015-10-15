using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public static int style = 0;
    public static int health = 4;
    private PlayerSounds sounds;

    void Awake()
    {        
        sounds = GetComponent<PlayerSounds>();
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Enemy"))
        {            
            sounds.playPlayerDamage();
            Player.health -= 1;
            Destroy(hit.gameObject);
        }
    }
}
