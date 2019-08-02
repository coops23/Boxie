using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 5.0f;
    public int damage = 5;
    public Rigidbody2D rb;
    
	void Start () 
    {
        rb.velocity = transform.right * speed;
	}
    
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag != "Player")
        {
            Health enemy = hitInfo.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }    
                    
    }
}
