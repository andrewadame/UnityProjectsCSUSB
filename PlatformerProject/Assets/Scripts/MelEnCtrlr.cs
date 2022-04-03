using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelEnCtrlr : EnCtrlr
{
    public override void Move()
    {

        dist = Vector2.Distance(transform.position, plyr.transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * dir, ryLgth, wlLyr);
        //If enemy hits wall, turn around
        if(hit.collider != null)
        {
            dir *= -1;
        }

        Debug.DrawRay(transform.position, Vector2.right * dir * ryLgth * wlLyr);

        if(dist <= chsRng)
        {
            crntSte = enStes.chase;
        }

        enRgdBdy.AddForce(Vector2.right * dir * spd * Time.deltaTime);
    }

    public override void Chase()
    {
        dist = Vector2.Distance(transform.position, plyr.transform.position);

        //If player is on left, go left. If right, go right
        if (transform.position.x > plyr.transform.position.x)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }

        //if player outside chase range, become passive
        if(dist >= chsRng)
        {
            crntSte = enStes.move;
        }

        //if player in attack range, attack
        if (dist <= atkRng)
        {
            crntSte = enStes.attack;
        }

        //Enter run speed
        enRgdBdy.AddForce(Vector2.right * dir * rnSpd * Time.deltaTime);

    }

    public override void Attack()
    {
        Debug.Log("Attack!");
    }

    public override void Damage(float amnt)
    {
        hlth -= amnt;
        if (hlth <= 0) Die();
    }

    public override void Die()
    {
        //Delete
        Destroy(gameObject);

        /*Disable
        gameObject.SetActive(false);
        */
    }
}
