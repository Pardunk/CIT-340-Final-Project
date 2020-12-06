using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Coin : MonoBehaviour
{ //Paige worked on P_Coin Script
   

    public int coinValue = 2;
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Coin GEt");

            P_CoinCounter.instance.ScoreChange(coinValue);
            
        }
    }
}
