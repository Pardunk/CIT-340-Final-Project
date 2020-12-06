using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_CoinCounter : MonoBehaviour
{ // Paige worked on P_CoinCounter script and UI
    public static GameObject instance = null;
    public Text scoreText;
    public Text levelText;
    [HideInInspector]public int score;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
            ScoreChange((int)PlayerPrefs.GetFloat("Experience"));

        instance = this.gameObject;

        levelText.text = "Level: " + level.ToString();
    }

    public void ScoreChange(int changeCoins)
    {
        score += changeCoins;
        scoreText.text = "Score: " + score.ToString();

        //show level 3
        if(score == 30)
        {
            level += 1;
            levelText.text = "Level: " + level.ToString();
        }
        //show level 2
        else if(score == 20)
        {
            level += 1;
            levelText.text = "Level: " + level.ToString();
        }
        //Show level 1
        else if(score == 10)
        {
            level += 1;
            levelText.text = "Level: " + level.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
