using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    int P1Score, P2Score;
    public int maxScore = 3;

    public Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score(bool P1GetScore)
    {
        if (P1GetScore)
            P1Score++;
        else
            P2Score++;

        if(P1Score >= maxScore)
        {
            scoreText.text = "Player 1 Wins!";
        }
        else if (P2Score >= maxScore)
        {
            scoreText.text = "Player 2 Wins!";
        }
        else
        {
            scoreText.text = P1Score + " : " + P2Score;
        }

    }

}
