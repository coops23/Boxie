using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource gunShot;
    
	// Update is called once per frame
	void Update () {
        Vector3 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        firePoint.rotation = Quaternion.LookRotation(mouseDirection,Vector3.forward);
        firePoint.eulerAngles = new Vector3(0,180.0f,firePoint.eulerAngles.z + 90);
        
		if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}
    
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        gunShot.Play();
    }
}
