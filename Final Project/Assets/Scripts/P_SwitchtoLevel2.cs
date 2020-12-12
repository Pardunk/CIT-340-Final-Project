using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_SwitchtoLevel2 : MonoBehaviour
{
    //Paige worked on this script
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetFloat("Score", P_CoinCounter.instance.GetComponent<P_CoinCounter>().score);

        SceneManager.LoadScene("Jared_Scene");
    }
}
