//Script by Drake Collier
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_ObstacleHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
            //STUBBED: whatever we want to happen to the player when they get hit by an enemy will go here.
            Debug.Log("Hit!");
    }
}
