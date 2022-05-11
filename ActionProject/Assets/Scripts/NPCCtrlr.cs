using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCtrlr : MonoBehaviour
{
    DialCtrlr diaCtrlr;
    public Dial[] dlgs;
    int crntDia = 0;

    private void Awake()
    {
        diaCtrlr = FindObjectOfType<DialCtrlr>();
    }

    private void OnMouseDown()
    {
        diaCtrlr.StrtDial(dlgs[crntDia]);
        crntDia = (crntDia + 1) % dlgs.Length;
    }
}
