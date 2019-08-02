using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject player;
    public GameObject enemy;
    public float spawnTime = 3f;
    
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
        if (player == null) { return; }
		if (player.GetComponent<Health>().health <= 0) { return; }
        
        int currentScore = Score.scoreValue;
        for(int i = 0; i < (currentScore / 100) + 1; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnLocations.Length);
            Vector3 spawnLocation = spawnLocations[spawnPointIndex].position;
            
            spawnLocation.x += Random.Range(0.0f, 1.0f);
            spawnLocation.y += Random.Range(0.0f, 1.0f);
            Instantiate(enemy, spawnLocation, spawnLocations[spawnPointIndex].rotation);
        }      
	}
}
