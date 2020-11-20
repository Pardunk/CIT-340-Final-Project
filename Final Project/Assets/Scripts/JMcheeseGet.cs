using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JMcheeseGet : MonoBehaviour
{


    AudioSource victory;


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
  
        victory = GetComponent<AudioSource>();
        victory.Play();

        Debug.Log("Cheese Get");
        // SceneManager.LoadScene("next level");
    }
}