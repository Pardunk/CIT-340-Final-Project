using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Coin : MonoBehaviour
{ //Paige worked on P_Coin Script
    public int coinValue = 2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            P_CoinCounter.instance.GetComponent<P_CoinCounter>().ScoreChange(coinValue);
            
        }
    }
}
