using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameTag : MonoBehaviour
{
    public int playerNum;

    [SerializeField]
    private TextMeshProUGUI textMP;

    void Start()
    {
        playerNum = gameObject.GetComponentInParent<PlayerHealth>().playerID;
        textMP.SetText("P" + playerNum.ToString());
    }
}
