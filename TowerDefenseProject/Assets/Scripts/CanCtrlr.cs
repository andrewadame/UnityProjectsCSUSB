using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanCtrlr : BseTwr
{
    public override void Shoot()
    {
        Instantiate(blt, transform.position, transform.rotation);
        cldwn = StSpd;
        base.Shoot();
    }
}
