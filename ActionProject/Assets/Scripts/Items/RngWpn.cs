using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RngWpn : Item
{
    public GameObject prjctle;

    public override void Use()
    {
        base.Use();
        Debug.Log("Use Ranged Weapon");

        if (inv.transform.localScale.x == 1)
        {
            Instantiate(prjctle, transform.position, transform.rotation * Quaternion.Euler(0, 0, -90));
        }

        if (inv.transform.localScale.x == -1)
        {
            Instantiate(prjctle, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        }
    }

    public override void Remove()
    {
        base.Remove();
        Debug.Log("Remove Ranged Weapon");
    }
}

