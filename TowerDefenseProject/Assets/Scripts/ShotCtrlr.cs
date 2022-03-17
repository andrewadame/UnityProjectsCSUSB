using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCtrlr : BseTwr
{
    public override void Shoot()
    {
        for (int i = 0; i < bltSpwnPos.Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Instantiate(blt, bltSpwnPos[i].transform.position, transform.rotation * Quaternion.Euler(0, 0, (i*5)-15f));
            }
        }

        srce.Play();
        Instantiate(flsh, bltSpwnPos[0].transform.position, transform.rotation);
        cldwn = StSpd;
        base.Shoot();
    }
}
