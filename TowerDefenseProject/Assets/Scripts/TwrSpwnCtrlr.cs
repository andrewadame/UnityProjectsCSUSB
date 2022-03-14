using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwrSpwnCtrlr : MonoBehaviour
{
    GmeCtrlr cont;

    SpriteRenderer rend;

    private void Awake()
    {
        cont = FindObjectOfType<GmeCtrlr>();
        rend = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        if (cont.mny >= cont.crntTwrCst)
        {
            //Debug.Log("Spawn Tower");
            cont.GveMny(-cont.crntTwrCst);
            Instantiate(cont.twr, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        if(cont.mny >= cont.crntTwrCst)
        {
            rend.color = Color.green;
        }
        else
        {
            rend.color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        rend.color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
