using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RngdEnCtrlr : EnCtrlr
{
    public GameObject bsBll;
    public override void Move()
    {

        dist = Vector2.Distance(transform.position, plyr.transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * dir, ryLgth, wlLyr);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.right * dir - Vector2.up, ryLgth, wlLyr);

        //If enemy hits wall, turn around
        if (hit.collider != null)
        {
            dir *= -1;
        }

        //If enemy hits ledge, turn around
        if (hitDown.collider == null)
        {
            //Debug.Log("Why tho");
            dir *= -1;
        }

        if (dist <= chsRng)
        {
            crntSte = enStes.chase;
        }

        Debug.DrawRay(transform.position, Vector2.right * dir * ryLgth * wlLyr);

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
        if (dist >= chsRng)
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
        if (atkCldwn <= 0)
        {
            //Debug.Log("Attack!");
            anim.SetBool("Attack", true);
            Vector3 dir = plyr.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            Instantiate(bsBll, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));

            Invoke("ResetAttack", 0.1f);
            atkCldwn = tmeBtwnAtk;
        }
        else
        {
            crntSte = enStes.chase;
        }
    }

    private void ResetAttack()
    {
        anim.SetBool("Attack", false);
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
