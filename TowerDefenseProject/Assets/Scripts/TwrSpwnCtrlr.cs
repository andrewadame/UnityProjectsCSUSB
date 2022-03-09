using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwrSpwnCtrlr : MonoBehaviour
{
    GmeCtrlr cont;

    private void Awake()
    {
        cont = FindObjectOfType<GmeCtrlr>();
    }
    private void OnMouseDown()
    {
        //Debug.Log("Spawn Tower");
        Instantiate(cont.twr, transform.position, transform.rotation);
        gameObject.SetActive(false);
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
