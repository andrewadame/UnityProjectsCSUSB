using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrlr : MonoBehaviour
{

    public List<ShopItem> shpItms = new List<ShopItem>();

    public List<ChestItem> chstItms = new List<ChestItem>();

    public List<ChestItem> cmnItms = new List<ChestItem>();
    public List<ChestItem> uncmnItms = new List<ChestItem>();
    public List<ChestItem> rareItms = new List<ChestItem>();
    public List<ChestItem> epicItms = new List<ChestItem>();
    public List<ChestItem> lgndItms = new List<ChestItem>();

    void Awake()
    {
        for(int i = 0; i < chstItms.Count; i++)
        {
            switch(chstItms[i].item.itmRarity)
            {
                case Item.rairty.common:
                    cmnItms.Add(chstItms[i]);
                    break;
                case Item.rairty.uncommon:
                    uncmnItms.Add(chstItms[i]);
                    break;
                case Item.rairty.rare:
                    rareItms.Add(chstItms[i]);
                    break;
                case Item.rairty.epic:
                    epicItms.Add(chstItms[i]);
                    break;
                case Item.rairty.legendary:
                    lgndItms.Add(chstItms[i]);
                    break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ShopItem GtRndItm(List<ShopItem> l)
    {
        int index = Random.Range(0, l.Count);
        ShopItem item = l[index];
        return item;

    }

    public ChestItem GtRndItm(List<ChestItem> l)
    {
        int index = Random.Range(0, l.Count);
        ChestItem item = l[index];
        return item;
    }
}
