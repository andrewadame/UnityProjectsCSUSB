using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestItem : MonoBehaviour
{
    public Item item;
    PlyrCtrlr plyr;
    Invtry invtry;
    SpriteRenderer rend;
    Text itmTxt;

    private void Awake()
    {
        plyr = FindObjectOfType<PlyrCtrlr>();
        invtry = FindObjectOfType<Invtry>();
        rend = GetComponent<SpriteRenderer>();
        itmTxt = GetComponentInChildren<Text>();

        rend.sprite = item.itmSprte;

    }

    public void PckUpItm()
    {
        invtry.AddItem(item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        PckUpItm();
    }

    private void Update()
    {
        itmTxt.text = item.itmNme;
    }

}
