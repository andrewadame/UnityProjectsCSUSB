using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int MaxPlayers;

    [SerializeField] public int maxScore; // meant to keep score

    public int gameMode = 0; //which game mode is going to be played

    public List<PlayerController> activePlayers = new List<PlayerController>();

    public string[] elimination_levels; // setup for elimination levels

    public string[] ctf_levels; // setup for capture the flag levels

    public string[] deathmatch_levels; // setup for deathmatch levels

    private List<string> levelOrder = new List<string>();

    [HideInInspector] public int lastPlayerNumber;

    public int pointsToWin;
    public List<int> roundWins = new List<int>();

    public GiveID GiveID; // For setting up player ID's

    private bool gameWon;

    public string winLevel;

    private int numEliminated;

    private int index = 1;

    public GameObject[] players;

    public int numPlayers;

    [HideInInspector] public bool EndGame;

    [SerializeField] private AudioSource victoryScreech;

    private void Awake() // on awake prevent the game manager from getting destroyed
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayer(PlayerController newPlayer) // add players to both a list and array and assigns id's to them
    {
        if(activePlayers.Count < MaxPlayers)
        {
            newPlayer.gameObject.GetComponent<PlayerHealth>().playerID = index;
            newPlayer.gameObject.GetComponentInChildren<ScoreBar>().gameManager = this;
            activePlayers.Add(newPlayer);
            index++;
            players[numPlayers] = newPlayer.gameObject;
            numPlayers++;
        }
        else
        {
            Destroy(newPlayer.gameObject);
        }
    }

    public void ActivatePlayers() // activates the players
    {
        foreach(PlayerController player in activePlayers)
        {
            player.gameObject.SetActive(true);
            player.GetComponent<PlayerHealth>().FillHealth();
            player.GetComponentInChildren<HealthBar>().SetMaxHealth(20);
            if (player.GetComponent<PlayerController>().jumpSpeed == -12)
            {
            player.GetComponent<PlayerController>().rb.gravityScale = -player.GetComponent<PlayerController>().rb.gravityScale;
            player.GetComponent<PlayerController>().rb.velocity = new Vector2(0.0f, -1.0f);
            player.GetComponent<PlayerController>().jumpSpeed = 12;
            player.GetComponent<PlayerController>().flipY();
            }
        }
    }

    public int CheckActivePlayers() // checks if there are players active in the hierarchy
    {
        int playerAliveCount = 0;
        for(int i = 0; i < activePlayers.Count; i++)
        {
            if(activePlayers[i].gameObject.activeInHierarchy)
            {
                playerAliveCount++;
                lastPlayerNumber = i;
            }
        }
        return playerAliveCount;
    }
    public void CheckScore_Deathmatch() // checks the deathmatch kills
    {
        EndGame = false;
        for(int i = 0; i < numPlayers; i++)
        {
            if(players[i].GetComponent<PlayerHealth>().killCounter >= maxScore)
            {
                victoryScreech.Play();
                EndGame = true;
                lastPlayerNumber = i;
                gameWon = true;
            }
        }
    }

    public void CheckScore_CTF() // checks the ctf score
    {
        EndGame = false;
        for(int i = 0; i < numPlayers; i++)
        {
            if(players[i].GetComponent<PlayerHealth>().scoreCounter >= maxScore)
            {
                victoryScreech.Play();
                EndGame = true;
                lastPlayerNumber = i;
                gameWon = true;
            }
        }
    }

    public void GoToNextArena() // handles the level randomization if the user wants to add more levels
    {
        if(!gameWon)
        {
            if(levelOrder.Count == 0)
            {
                List<string> allLevelList = new List<string>();
                if(gameMode == 0)
                {
                    allLevelList.AddRange(elimination_levels);
                    for(int i = 0; i < elimination_levels.Length; i++)
                    {
                        int selected = Random.Range(0, allLevelList.Count);
                        levelOrder.Add(allLevelList[selected]);
                        allLevelList.RemoveAt(selected);
                    }
                }
                if(gameMode == 1)
                {
                    allLevelList.AddRange(deathmatch_levels);
                    for(int i = 0; i < deathmatch_levels.Length; i++)
                    {
                        int selected = Random.Range(0, allLevelList.Count);
                        levelOrder.Add(allLevelList[selected]);
                        allLevelList.RemoveAt(selected);
                    }
                }
                if(gameMode == 2)
                {
                    allLevelList.AddRange(ctf_levels);
                    for(int i = 0; i < ctf_levels.Length; i++)
                    {
                        int selected = Random.Range(0, allLevelList.Count);
                        levelOrder.Add(allLevelList[selected]);
                        allLevelList.RemoveAt(selected);
                    }
                }
            }
            string levelToLoad = levelOrder[0];
            levelOrder.RemoveAt(0);

            foreach(PlayerController player in activePlayers) // after a round fill all the players health to full
            {
                player.gameObject.SetActive(true);
                player.GetComponent<PlayerHealth>().FillHealth();
            }

            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            foreach(PlayerController player in activePlayers)
            {
                player.gameObject.SetActive(false);
                player.GetComponent<PlayerHealth>().FillHealth();
            }
            SceneManager.LoadScene(winLevel);
        }
    }

    public void StartFirstRound() // starts the first round of the game
    {
        roundWins.Clear();
        foreach(PlayerController player in activePlayers)
        {
            roundWins.Add(0);
        }
        gameWon = false;
        GoToNextArena();
    }

    public void AddRoundWin() // a function that calls on other functions to either add winners for a round or to see if the game is running
    {
        if(gameMode == 0) // gamemode is elimination
        {
            if(CheckActivePlayers() == 1)
            {
                roundWins[lastPlayerNumber]++;
                players[lastPlayerNumber].GetComponentInChildren<ScoreBar>().slider.value = roundWins[lastPlayerNumber];
                if(roundWins[lastPlayerNumber] >= pointsToWin)
                {
                    victoryScreech.Play();
                    gameWon = true;
                }
            }
        }
        if(gameMode == 1) // gamemode is deathmatch
        {
            CheckScore_Deathmatch();
        }
        if(gameMode == 2) // gamemode is ctf
        {
            CheckScore_CTF();
        }
    }
}