using UnityEngine;
using System.Collections;

public class PlayerLeftClick : MonoBehaviour {
    SpriteRenderer playerStance;
    public Sprite crossbow;
    public Sprite dagger;
    private PlayerSounds sounds;
    Vector3 targetPos; 
	

	void Start () {
        playerStance = GetComponent<SpriteRenderer>();
        sounds = GetComponent<PlayerSounds>();
	}	
	void Update () {       
        if (Input.GetMouseButtonDown(0))            
        {
            if (0 < Input.mousePosition.x && Input.mousePosition.x < Screen.width &&
                0 < Input.mousePosition.y && Input.mousePosition.y < Screen.height)
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                attack(targetPos);
            }            
        }
	}    

    /// <summary>
    /// Takes a targetPosition (where the player clicked) and teleports to it if there is a target between the path from the player to
    /// the position and if the attack style is melee.
    /// Otherwise, fires a shot and kills the first thing it hits if the attack style is ranged.
    /// </summary>
    /// <param name="targetPos"></param>
    void attack(Vector3 targetPos){
        RaycastHit2D []hits = Physics2D.RaycastAll(transform.position, targetPos - transform.position);                     
        switch (Player.style)
        {
            case 0:
                bool contacted = false;
                foreach (RaycastHit2D hit in hits)
                {                    
                    if (hit.collider.CompareTag("Enemy") && checkDistance(hit.collider.gameObject, targetPos))
                    {
                        hit.collider.GetComponent<Enemy>().slay();                       
                        contacted = true;
                    }
                }
                if (contacted)
                {
                    sounds.playMeleeAttack();                    
                    this.transform.position = new Vector2(targetPos.x, targetPos.y);
                    switchCombatStyle();
                }
                break;
            case 1:
                if (hits.Length > 0)
                {
                    sounds.playRangeAttack();                    
                    if (hits[0].collider.CompareTag("Enemy"))
                    {                        
                        hits[0].collider.GetComponent<Enemy>().slay();                        
                    }
                    switchCombatStyle();
                }
                break;                           
        }
    }

    /// <summary>
    /// Switches the player's combat style appropriately after an attack:
    /// From melee to ranged || from ranged to melee
    /// </summary>
    void switchCombatStyle()
    {
        switch (Player.style)
        {
            case 0:
                playerStance.sprite = crossbow;
                Player.style = 1;
                sounds.playRangeSwitch();
                break;
            case 1:
                playerStance.sprite = dagger;
                Player.style = 0;
                sounds.playMeleeSwitch();
                break;
        }
    }
    /// <summary>
    /// Verifies that the distance between the player and a clicked position is greater than the distance between the player and a target
    /// along the attack line.
    /// </summary>
    bool checkDistance(GameObject hit, Vector3 targetPos)
    {
        return Vector2.Distance(transform.position, targetPos) >= Vector2.Distance(transform.position, hit.transform.position);
    }
}
