using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// will be merged into fire projectileGun script
public class bulletProjectile : MonoBehaviour
{

    public float speed; //speed that bullet travels
    public Rigidbody2D rb; //gives bullet rigidbody to give it physics
    public int dmg; //Damage amount bullet does

    public GameObject playerAttacker; //Player that shot the bullet

    // Game Object for animation that plays when bullet hits something
    // public GameObject hitDetectionAni;

    void Start()
    {
        rb.velocity = transform.right * speed; //When player shoots bullet travels right
    }

    //find a way to place this into new hitDetection script?
    void OnTriggerEnter2D (Collider2D hitDetection)
    {
        PlayerHealth playerHit = hitDetection.GetComponent<PlayerHealth>();
        
        if (playerHit != null)
        {
            playerHit.calcDmg(dmg, playerAttacker);
            Destroy(gameObject);
        }
        if (hitDetection.gameObject.CompareTag("Terrain") || (hitDetection.gameObject.CompareTag("Projectile")) )
        {
            Destroy(gameObject);
        }

        //add feature to play hitDetectionAni when in contact
    }
}
