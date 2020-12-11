using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class P_EndtoMainMenu : MonoBehaviour
{
    public Text winText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(BeatLevel());
    }

    IEnumerator BeatLevel()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<JMPlayerMove>().canMove = false;

        winText.text = "You Did It!";

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("P_MainMenu");
    }
}
