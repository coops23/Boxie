using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public int health;
    public Text healthText;
    public Animator animator;
    public ZombieDeath zombieDeathPrefab;
    
	// Use this for initialization
	void Start () {
        if (healthText != null) { healthText.text = "Health: " + health.ToString(); }
	}
	
	// Update is called once per frame
	void Update () {
	}
    
    public void TakeDamage (int damage) 
    {              
        health = health - damage;
        StartCoroutine ("DamageAnimate");
        if(health <= 0) 
        { 
            health = 0;
            Die(); 
        }
        
        if(healthText != null)
            healthText.text = "Health: " + health.ToString();
    }
    
    IEnumerator DamageAnimate()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);      
        renderer.color = Color.white;
        yield return new WaitForSeconds(0.2f); 
    }    
    
    private void Die ()
    {   
        if (gameObject.tag == "Enemy")
        {
            Score.scoreValue += 10;
            Instantiate(zombieDeathPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if(gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Application.LoadLevel("EndScreen");
        }             
    }
}
