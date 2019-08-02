using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour {

    public float speed;
    public Animator animator;
    
	// Update is called once per frame
	void Update () {
        Vector3 keyboardMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        Vector3 mouseMovement = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mouseMovement.z = 0;   
    
        animator.SetFloat("Horizontal", mouseMovement.x);
        animator.SetFloat("Vertical", mouseMovement.y);
        
        animator.SetFloat("Magnitude", keyboardMovement.magnitude);
        
        transform.position = transform.position + (keyboardMovement * Time.deltaTime * speed);
    }
}
