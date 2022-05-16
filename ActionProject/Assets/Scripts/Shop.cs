using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public float intrctDist;
    [SerializeField]
    float dist;

    public GameObject shpPrnt;
    PlyrCtrlr plyr;

    GameCtrlr cont;

    // Start is called before the first frame update
    void Awake()
    {
        plyr = FindObjectOfType<PlyrCtrlr>();
        cont = FindObjectOfType<GameCtrlr>();
        PopShop();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(transform.position, plyr.transform.position);
        if(dist <= intrctDist)
        {
            shpPrnt.SetActive(true);
        }
        else
        {
            shpPrnt.SetActive(false);
        }
    }
    
    public void PopShop()
    {
        ShopItem shpItm;
        for (int i = 0; i < 3; i++)
        {
            //shpItm = Instantiate(cont.shpItms[i]);
            shpItm = Instantiate(cont.GtRndItm(cont.shpItms));
            shpItm.transform.SetParent(shpPrnt.transform);
            shpItm.transform.localPosition = new Vector3((i * 0.5f) - 0.5f, 0, 0);

        }

    }
}
