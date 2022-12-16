using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponDespawn : MonoBehaviour
{
    // is weapon equipped on a player
    public bool equipped;
    public float timeToDespawn, countDown;

    // when weapon spawns begin despawn timer
    private void Awake()
    {
        equipped = false;
        countDown = timeToDespawn;
    }

    // Check if weapon is equipped or out of ammo (for future)
    // if not equipped begin despawn countdown timer
        // if despawn timer hits zero destroy gameobject
    //if out of ammo (for future)
        //destroy gameobject
    private void Update()
    {
        if (!gameObject.GetComponent<fireProjectileGun>().isFlag)
        {
            if(!equipped)
            {
                countDown -= Time.deltaTime;
                if (countDown <= 0)
                {
                    Destroy(gameObject);
                }
            }
            if (gameObject.GetComponent<fireProjectileGun>().ammo <= 0 && !equipped)
            {
                Destroy(gameObject);
            }
        }
    }

    public void DropAfterRoundEnds()
    {
        Destroy(gameObject);
    }
}
