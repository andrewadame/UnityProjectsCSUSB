using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Csmble : Item
{
    public int uses;

    public override void Use()
    {
        base.Use();
        Debug.Log("Use Consumable");

        if(uses > 0)
        {
            uses--;
            FindObjectOfType<PlyrCtrlr>().Heal(amnt);
        }
        else
        {
            Remove();
        }
    }

    public override void Remove()
    {
        base.Remove();
        Debug.Log("Remove Consumable");
    }

}
