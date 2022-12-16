using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFlag : MonoBehaviour
{
    [SerializeField]
    public GameObject flag;

    [SerializeField]
    private Transform flagSpawn;

    void Start() // spawns the flag into the arena
    {
        flag.SetActive(true);
        flag.GetComponent<flagRespawn>().sp = flagSpawn;
    }
}
