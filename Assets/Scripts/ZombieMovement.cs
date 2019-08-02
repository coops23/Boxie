using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour {

    public float speed;
    public Animator animator; 
    public float attackRate;
    public int damage;
    
    private bool attacking;
    private Collision2D playerAttacked;
    private float attackingTimer;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        attacking = false;
    }
    
	// Update is called once per frame
	void Update () {
        if (transform != null)
        {
            Vector3 heading = player.transform.position - transform.position; 
            Vector3 movement = heading / heading.magnitude; // This is now the normalized direction.
            
            if(!attacking)
            {       
                transform.position = transform.position + (movement * Time.deltaTime * speed);
            }
            else
            {
                attackingTimer += Time.deltaTime;
                if (attackingTimer > attackRate)
                {
                    Health playerHealth = playerAttacked.gameObject.GetComponent("Health") as Health;
                    playerHealth.TakeDamage(10);
                    attackingTimer = 0.0f;
                }
            }
                
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Magnitude", heading.magnitude);           
        }
        
    }   
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attacking = true;
            playerAttacked = collision;
            attackingTimer = 0.0f;
            animator.SetBool("Attacking", true);
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attacking = false;
            playerAttacked = null;
            attackingTimer = 0.0f;
            animator.SetBool("Attacking", false);
        }
    }
}


