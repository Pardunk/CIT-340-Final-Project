using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_CoinCounter : MonoBehaviour
{
    public static P_CoinCounter instance;
    public Text text;
    int score;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
       
        
    }

    public void ScoreChange(int changeCoins)
    {
        score += changeCoins;
        text.text = "Score: " + score.ToString();
        //Show level 1
        if(score == 10)
        {
            level += 1;
            text.text = "Level: " + level.ToString();
        }
        //show level 2
        if(score == 20)
        {
            level += 1;
            text.text = "Level: " + level.ToString();
        }
        //show level 3
        if(score == 30)
        {
            level += 1;
            text.text = "Level: " + level.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
