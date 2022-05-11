using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itmNme;
    public string itmDesc;
    public int itmCst;
    public bool itmRot;
    public float amnt;  //position add amount to plyr hlth value, weapon decrease amnt of en hlh

    public Sprite itmSprte;
    protected Invtry inv;

    SpriteRenderer itmRend;

    private void Awake()
    {
        inv = FindObjectOfType<Invtry>();
        itmRend = GetComponent<SpriteRenderer>();
        itmRend.sprite = itmSprte;
    }


    public virtual void Use()
    {
        Debug.Log("base use");
    }

    public virtual void Remove()
    {
        inv.RemoveItem(this);
    }

}
