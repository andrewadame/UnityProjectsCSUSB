using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public GameObject chstPrnt;
    PlyrCtrlr plyr;

    GameCtrlr cont;

    bool populated = false;
    void Awake()
    {
        plyr = FindObjectOfType<PlyrCtrlr>();
        cont = FindObjectOfType<GameCtrlr>();
        PopChst();
    }

    public void PopChst()
    {
        ChestItem chstItm;
        for (int i = 0; i < 3; i++)
        {
            int r = Random.Range(0, 100);
            if(r < 3 && cont.lgndItms.Count != 0) //Legendary
            {
                Debug.Log("Legendary!");
                chstItm = Instantiate(cont.GtRndItm(cont.lgndItms));
                chstItm.transform.SetParent(chstPrnt.transform);
                chstItm.transform.localPosition = new Vector3((i * 0.5f) - 0.5f, 0, 0);
            }
            else if (r < 10 && cont.epicItms.Count != 0) //Epic
            {
                Debug.Log("Epic!");
                chstItm = Instantiate(cont.GtRndItm(cont.epicItms));
                chstItm.transform.SetParent(chstPrnt.transform);
                chstItm.transform.localPosition = new Vector3((i * 0.5f) - 0.5f, 0, 0);
            }
            else if (r < 30 && cont.rareItms.Count != 0) //Rare
            {
                Debug.Log("Rare!");
                chstItm = Instantiate(cont.GtRndItm(cont.rareItms));
                chstItm.transform.SetParent(chstPrnt.transform);
                chstItm.transform.localPosition = new Vector3((i * 0.5f) - 0.5f, 0, 0);
            }
            else if (r < 50 && cont.uncmnItms.Count != 0) //Uncommon
            {
                Debug.Log("Uncommon!");
                chstItm = Instantiate(cont.GtRndItm(cont.uncmnItms));
                chstItm.transform.SetParent(chstPrnt.transform);
                chstItm.transform.localPosition = new Vector3((i * 0.5f) - 0.5f, 0, 0);
            }
            else if (cont.cmnItms.Count != 0)//Common
            {
                Debug.Log("Common!");
                chstItm = Instantiate(cont.GtRndItm(cont.cmnItms));
                chstItm.transform.SetParent(chstPrnt.transform);
                chstItm.transform.localPosition = new Vector3((i * 0.5f) - 0.5f, 0, 0);
            }
            else
            {
                Debug.Log("No items in chest!");
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!populated && collision.gameObject.CompareTag("Player"))
        {
            PopChst();
            populated = true;
        }
    }
}