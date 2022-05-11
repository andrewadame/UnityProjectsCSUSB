using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invtry : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    [SerializeField]
    int iSlot = 0;  //index of current equipped item
    [SerializeField]
    int nxtSlot = 0;
    [SerializeField]
    bool rot = false;

    public SpriteRenderer parentRend;

    public Item item1;
    public Item item2;
    public Item item3;


    public void Awake()
    {
        AddItem(item1);
        AddItem(item2);
        AddItem(item3);
        nxtSlot = iSlot;
    }

    public void Update()
    {
        if(rot)
        {
            Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * 10f);
        }

        transform.localScale = new Vector3(parentRend.flipX ? -1:1, 1, 1);

        if(Input.GetKeyDown(KeyCode.Z)) //equip an item
        {
            if (items.Count != 0)
            {
                EquipItem(nxtSlot);
                Debug.Log("Next Item!");
            }
            else
            {
                Debug.Log("No items in inventory!");
            }
        }

        if (Input.GetKeyDown(KeyCode.X)) //use equipped item
        {
            if(items[iSlot] != null)
            {
                items[iSlot].Use();
            }
        }

        if (Input.GetKeyDown(KeyCode.C)) //remove an item
        {
            if (items[iSlot] != null)
            {
                RemoveItem(items[iSlot]);
            }
        }
    }

    public void AddItem(Item item)
    {
        Item nwItem = Instantiate(item);
        nwItem.transform.SetParent(transform);
        nwItem.transform.localPosition = Vector3.zero;
        nwItem.transform.localRotation = Quaternion.identity;
        items.Add(nwItem);
        nwItem.gameObject.SetActive(false);

    }

    public void EquipItem(int slot)
    {
        if(items.Count != 0)
        {
            items[iSlot % items.Count].gameObject.SetActive(false);
            iSlot = slot % items.Count;
            items[iSlot].gameObject.SetActive(true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rot = items[iSlot].itmRot;
            nxtSlot = (iSlot + 1) % items.Count;


        }
    }

    public void RemoveItem(Item item)
    {
        if (items.Count != 0)
        {
            items.Remove(item);
            item.gameObject.SetActive(false);
        }
    }

}
