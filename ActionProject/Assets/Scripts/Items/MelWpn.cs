using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelWpn :Item
{
    Animator anim;
    public LayerMask enLyr;
    public float rayLngth;


    public override void Use()
    {
        base.Use();
        Debug.Log("Use Melee Weapon");
        FindObjectOfType<Animator>().SetTrigger("Strike");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, rayLngth, enLyr);

        if(hit.collider != null && hit.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit " + hit.collider.name);
        }

        Debug.DrawRay(transform.position, Vector2.right * rayLngth);

    }

    public override void Remove()
    {
        base.Remove();
        Debug.Log("Remove Melee Weapon");
    }
}

