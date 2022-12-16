using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectUI : MonoBehaviour
{
    public GameObject joinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // Turns off the join text when the max number of players join the game
    {
        if(GameManager.instance.activePlayers.Count >= GameManager.instance.MaxPlayers)
        {
            joinText.SetActive(false);
        }
        else
        {
            joinText.SetActive(true);
        }
    }
}
