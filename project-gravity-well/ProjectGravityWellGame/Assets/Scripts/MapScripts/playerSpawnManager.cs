using UnityEngine;
using UnityEngine.InputSystem;

public class playerSpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations; //spawns locations for beginning of match
    public int numPlayers; //Total number of players in match
    public GameObject[] players; //Array with each of the players

    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.gameObject.GetComponent<PlayerHealth>().playerID = playerInput.playerIndex + 1; //gives player an id number

        playerInput.gameObject.GetComponent<PlayerHealth>().startPos = spawnLocations[playerInput.playerIndex].position; //spawns player at specific spawn

        numPlayers++; //Increase the number of players in the game
        players[numPlayers] = playerInput.gameObject; //Stores player in to the array.

        //Temporary color changer until character ready screen is done
        if (numPlayers == 2) playerInput.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        else if (numPlayers == 3) playerInput.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
        else if (numPlayers == 4) playerInput.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
    }
}
