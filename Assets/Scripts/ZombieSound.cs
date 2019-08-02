using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ZombieSound : MonoBehaviour {

     public AudioSource sound;
     public float timeBetweenSounds = 2.0f;
      
     void Start () {
        InvokeRepeating("Sound", 0.0f, timeBetweenSounds);
     }
     
     void Sound ()
     {     
        float value = Random.Range(0.0f, 1.0f);
        
        if (value <= 0.5)
        {
            sound.Play();
        }
     }
}
