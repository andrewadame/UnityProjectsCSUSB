using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanCtrlr : BseTwr
{
    public override void Shoot()
    {
        Instantiate(blt, bltSpwnPos[0].transform.position, transform.rotation);
        srce.Play();
        Instantiate(flsh, bltSpwnPos[0].transform.position, transform.rotation);
        cldwn = StSpd;
        base.Shoot();
    }
}
