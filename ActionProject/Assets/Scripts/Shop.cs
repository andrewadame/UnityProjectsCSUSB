using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public float intrctDist;
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

    }
}
