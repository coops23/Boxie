using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour {

    public AudioSource audio;
    
	// Use this for initialization
	void Start () {
		StartCoroutine ("DeathAnimate");
	}
	
	IEnumerator DeathAnimate()
    {
        audio.Play();
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
