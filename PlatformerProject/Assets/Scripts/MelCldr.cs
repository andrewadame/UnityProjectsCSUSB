using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelCldr : MonoBehaviour
{
    public SpriteRenderer prntRnd;
    public float atk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if MelEn, flipX is false. If false, x = -1
        transform.localScale = new Vector3(prntRnd.flipX? -1 : 1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlyrCtrlr>().dmg(atk);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlyrCtrlr>().dmg(atk);
        }
    }
}
