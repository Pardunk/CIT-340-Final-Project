//Script by Drake Collier
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_ObstacleHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
            GameObject.FindGameObjectWithTag("Player").GetComponent<JMPlayerMove>().Respawn();
    }
}
