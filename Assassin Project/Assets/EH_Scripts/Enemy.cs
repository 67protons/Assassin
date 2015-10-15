using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float speed = 1f;
    public GameObject soul;
    Animator anim;
    int deathHash = Animator.StringToHash("Enemy Death");
    int alertHash = Animator.StringToHash("Enemy Alert");
    int chasingStateHash = Animator.StringToHash("Base Layer.Enemy Chasing");
    Transform player;
    float step;

    void Start()
    {        
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash == chasingStateHash){
            step = speed * Time.deltaTime;            
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
    }

    public void slay()
    {       
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        this.tag = "Untagged";
        anim.SetTrigger(deathHash);
        GameManager.slain += 1;
        Invoke("death", .15f);
    }

    void death()
    {
        dropSoul();
        Destroy(this.gameObject);
    }

    void dropSoul()
    {
        Instantiate(soul, this.transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
            anim.SetTrigger(alertHash);
    }
}
