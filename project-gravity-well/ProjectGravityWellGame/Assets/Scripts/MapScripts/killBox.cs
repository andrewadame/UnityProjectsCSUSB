using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBox : MonoBehaviour
{
    // kills the player if they collide with anything that has this script attached
    pickUpDropFire dropWeapon;

    [SerializeField] private AudioSource Oof;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if(GameManager.instance.gameMode == 0)
            {
                Oof.Play();
                collider.gameObject.GetComponent<pickUpDropFire>().dropDead();
                collider.gameObject.SetActive(false);
            }
            if(GameManager.instance.gameMode == 1 || GameManager.instance.gameMode == 2)
            {
                Oof.Play();
                collider.GetComponent<PlayerHealth>().playerDeath();
            }
        }
        if (collider.gameObject.CompareTag("Weapon"))
        {
            if(collider.gameObject.GetComponent<fireProjectileGun>().isFlag)
            {
                return;
            }
        }
    }
}
