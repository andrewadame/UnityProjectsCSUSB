using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagRespawn : MonoBehaviour
{
    public Transform sp;
    [SerializeField]
    private float respawnCD, respawnTime = 10, flagTime = 5, flagCD;

    private bool countDown, scored;

    public GameObject playerHeld;

    [SerializeField] AudioSource ScorePoint;

    void Start()
    {
        respawnCD = respawnTime;
        countDown = false;
    }

    void Update() // handles repspawing of the flag
    {
        if (countDown)
        {   
            if (!gameObject.GetComponent<weaponDespawn>().equipped)
            {
                respawnCD -= Time.deltaTime;
                if (respawnCD <= 0)
                {
                    gameObject.transform.position = sp.position;
                    gameObject.transform.rotation = sp.rotation;
                }
            }
            else
            {
                respawnCD = respawnTime;
            }
        }
        else
        {
            respawnCD = respawnTime;
        }
        if (scored)
        {
            flagCD -= Time.deltaTime;
            if (flagCD <= 0)
            {
                scored = false;
                gameObject.transform.position = sp.position;
                gameObject.transform.rotation = sp.rotation;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("FlagSpawn"))
        {
            countDown = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) // gives points to whoever places the flag down in the correct spot
    {
        if (collider.gameObject.CompareTag("FlagSpawn"))
        {
            countDown = false;
        }

        if (collider.gameObject.CompareTag("FlagPoint") && !gameObject.GetComponent<weaponDespawn>().equipped)
        {
            if (!scored)
            {
                Debug.Log(playerHeld.GetComponent<PlayerHealth>().playerID);
                playerHeld.GetComponent<PlayerHealth>().scoreCounter++;
                Debug.Log("Score is: " + playerHeld.GetComponent<PlayerHealth>().scoreCounter);
                Vector3 temp = new Vector3(1000f,0,0);
                gameObject.transform.position += temp;
                scored = true;
                if(playerHeld.GetComponent<PlayerHealth>().scoreCounter >= GameManager.instance.maxScore)
                {
                    flagCD = 9999999999999999999;
                }
                else
                {
                    flagCD = flagTime;
                }
                ScorePoint.Play();
            }
        }
    }
}