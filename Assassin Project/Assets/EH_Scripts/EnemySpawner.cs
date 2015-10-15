using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public float spawnInterval = 1f;
    public Transform enemy1;
    Vector3 worldBounds;
    float cooldown;
    int pad = 1;
    Transform player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Start()
    {
        cooldown = spawnInterval;
        worldBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)); 
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            for (int i = 0; i < GameManager.level/10 + 1; i++)
            {
                Vector3 randomPos;
                do
                {
                    randomPos = new Vector3(Random.Range(-worldBounds.x + pad, worldBounds.x - pad),
                                            Random.Range(-worldBounds.y + pad, worldBounds.y - pad), 0);
                } while (player.position.x - 1 < randomPos.x && randomPos.x < player.position.x + 1 || 
                         player.position.y - 1 < randomPos.y && randomPos.y < player.position.y + 1);
                Instantiate(enemy1, randomPos, Quaternion.identity);
            }            
            cooldown = spawnInterval;
        }
        
    }
}
