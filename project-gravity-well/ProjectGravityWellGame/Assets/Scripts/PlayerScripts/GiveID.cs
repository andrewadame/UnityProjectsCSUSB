using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GiveID : MonoBehaviour
{
    public int numPlayers; //Total number of players in match
    public GameObject[] players; //Array with each of the players

    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.gameObject.GetComponent<PlayerHealth>().playerID = playerInput.playerIndex + 1; //gives player an id number
        players[numPlayers] = playerInput.gameObject; //Stores player in to the array.
        numPlayers++; //Increase the number of players in the game
    }
}
