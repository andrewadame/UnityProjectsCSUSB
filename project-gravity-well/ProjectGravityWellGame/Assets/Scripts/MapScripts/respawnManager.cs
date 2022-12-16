using UnityEngine;

public class respawnManager : MonoBehaviour
{
    public static respawnManager instance; // Will make this easy to reference by other scripts

    [SerializeField]
    public Transform[] pSP;

    // On awake set the respawn manager to the current instance
    private void Awake()
    {
        instance = this;
    }

    //Moves player to a spawn point
    public void respawnAt(Transform spawnPoint, GameObject player)
    {
        player.transform.position = spawnPoint.position; 
    }

    //Gets a random respawn point for player to go to
    public Transform randomRespawn(Transform[] pSP)
    {
        int rndNum = Random.Range(0, pSP.Length); //Generates a random number 

        Transform rsp = pSP[rndNum]; // Sets the random spawn point to what was randomly selected
        return rsp;
    }
}