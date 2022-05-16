using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
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

    public void BuyItm()
    {
        if(plyr.mny >= item.itmCst)
        {
            plyr.AddMny(-item.itmCst);
            invtry.AddItem(item);
            Destroy(gameObject);
        }

    }

    private void OnMouseDown()
    {
        BuyItm();
    }

    private void Update()
    {
        itmTxt.text = item.itmNme + "\n" + item.itmCst;
        itmTxt.color = plyr.mny > item.itmCst ? Color.green : Color.red;
    }

}
