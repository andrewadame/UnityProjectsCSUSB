using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenController : MonoBehaviour
{
    public TMP_Text WinnerText;
    
    public Image playerImage;

    public string mainMenuScene, charSelectScene;
    // Start is called before the first frame update
    void Start() // marks who won in the game
    {
        WinnerText.text = "Player " + (GameManager.instance.lastPlayerNumber + 1) + " Wins the Game!";
        //playerImage.sprite = GameManager.instance.activePlayers[GameManager.instance.lastPlayerNumber].GetComponent<SpriteRenderer>().sprite;
    }

    public void PlayAgain()
    {
        ClearGame();
        SceneManager.LoadScene(charSelectScene);
    }

    public void MainMenu() // go back to the main menu
    {
        ClearGame();
        SceneManager.LoadScene(mainMenuScene);
    }

    public void ClearGame() // clears the game and destroy's the game manager to prevent it from creating infinite copies
    {
        if (GameManager.instance.gameMode == 2)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Weapon");
            foreach (GameObject target in gameObjects)
            {
                GameObject.Destroy(target);
            } 
            Destroy(DontDestroy.instance.gameObject);
            DontDestroy.instance = null;
        }
        foreach(PlayerController player in GameManager.instance.activePlayers)
        {
            Destroy(player.gameObject);
        }
        Destroy(GameManager.instance.gameObject);
        GameManager.instance = null;
    }

}
