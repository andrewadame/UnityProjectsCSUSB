using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGameChecker : MonoBehaviour
{
    public string levelToLoad;

    private int playersInZone;

    public TMP_Text startcountText;

    public float timeToStart = 3f;

    private float startCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // checks if there are enough players in the zone
    {
        if(playersInZone > 1 && playersInZone == GameManager.instance.activePlayers.Count)
        {
            startcountText.gameObject.SetActive(true);
            startCounter-= Time.deltaTime;
            startcountText.text = Mathf.CeilToInt(startCounter).ToString();
            if(startCounter <= 0)
            {
                GameManager.instance.StartFirstRound();
            }
        }
        else // set the count down text to false when all of the players are in the area
        {
            startcountText.gameObject.SetActive(false);
            startCounter = timeToStart;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // check if there are players in the zone then increase the counter
    {
        if(other.tag == "Player")
        {
            playersInZone++;
        }
    }

        private void OnTriggerExit2D(Collider2D other) // when a player leaves the zone then remove them from the counter
    {
        if(other.tag == "Player")
        {
            playersInZone--;
        }
    }
}
