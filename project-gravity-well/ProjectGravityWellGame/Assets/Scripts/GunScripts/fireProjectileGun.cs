using UnityEngine;
using System.Collections;

public class fireProjectileGun : MonoBehaviour
{
    // Rework this script
    public bool isFlag;

    [SerializeField] private AudioSource BlickySoundEffect, OOM;

    public Transform firepoint; //point from gun that bullet is shot from
    public GameObject bulletPrefab; //bullet prefab that will be shot


    [SerializeField] 
    private int magazine, bulletDamage;
    public int ammo;
    public int ammoPerShot;

    [SerializeField] private float burstDelay, shotDelay, bulletSpeed;

    private bool isShooting;

    void Start()
    {
        ammo = magazine; // initializes the ammo to the magazine amount
        isShooting = false;
    }


    public IEnumerator Shoot(GameObject playerAttacker)
    {
        if(ammo > 0 && !isShooting) // checks if ammo is greater than 0 if so then shoot
        {
            isShooting = true;
            BlickySoundEffect.Play();
            for(int i = 0; i < ammoPerShot; i++)
            {
                GameObject bullet = bulletPrefab;
                bullet.GetComponent<bulletProjectile>().playerAttacker = playerAttacker;
                bullet.GetComponent<bulletProjectile>().speed = bulletSpeed;
                bullet.GetComponent<bulletProjectile>().dmg = bulletDamage;
                Instantiate(bullet, firepoint.position, firepoint.rotation);
                ammo--; // decreases ammo by 1 after shooting
                yield return new WaitForSeconds(shotDelay);
            }
            yield return new WaitForSeconds(shotDelay);
            isShooting = false;
        }
        else if(ammo <= 0) // if there is no more ammo in the gun then play a sound to indicate that there are no more bullets
        {
            OOM.Play();
        }
    }
}