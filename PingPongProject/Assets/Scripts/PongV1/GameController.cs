using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    int P1Score, P2Score;
    public int maxScore = 3;

    public Text scoreText;

    public GameObject gameOverUI;
    bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            if (Input.anyKeyDown)
                Restart();
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
            gameOver = true;
            GameOver();
        }
        else if (P2Score >= maxScore)
        {
            scoreText.text = "Player 2 Wins!";
            gameOver = true;
            GameOver();
        }
        else
        {
            scoreText.text = P1Score + " : " + P2Score;
        }

    }
    void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void Restart()
    {
        SceneManager.LoadScene("PongV1");
        Time.timeScale = 1f;
    }

}
