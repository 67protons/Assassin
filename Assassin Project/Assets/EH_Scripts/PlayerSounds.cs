using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {    
    public AudioClip meleeAttack;
    public AudioClip rangeAttack;
    public AudioClip meleeSwitch;
    public AudioClip rangeSwitch;
    public AudioClip playerDamage;

    private static AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void playMeleeAttack()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(meleeAttack, vol);
    }

    public void playRangeAttack()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(rangeAttack, vol);
    }

    public void playMeleeSwitch()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(meleeSwitch, vol);
    }

    public void playRangeSwitch()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(rangeSwitch, vol);
    }

    public void playPlayerDamage()
    {        
        source.PlayOneShot(playerDamage, 2f);
    }
}
