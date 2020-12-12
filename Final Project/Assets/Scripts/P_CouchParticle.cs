using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_CouchParticle : MonoBehaviour
{ //Paige worked on this script
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            GetComponent<ParticleSystem>().Play();

        }
    }
}
