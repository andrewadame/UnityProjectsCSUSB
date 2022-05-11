using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialCtrlr : MonoBehaviour
{
    Dial crntDl;

    public Text nmeUI;
    public Text dialUI;
    public GameObject UIPrnt;
    int crntIdx;

    public void StrtDial(Dial d)
    {
        crntDl = d;
        UIPrnt.SetActive(true);
        crntIdx = 0;
        nmeUI.text = crntDl.npcNme;
        dialUI.text = crntDl.dial[crntIdx];

    }

    public void NxtLne()
    {
        crntIdx++;
        if(crntIdx < crntDl.dial.Length)
        {
            nmeUI.text = crntDl.npcNme;
            dialUI.text = crntDl.dial[crntIdx];
        }
        else
        {
            extDial();
        }
    }

    public void extDial()
    {
        dialUI.text = "";
        nmeUI.text = "";
        UIPrnt.SetActive(false);
        crntIdx = 0;
    }
}
