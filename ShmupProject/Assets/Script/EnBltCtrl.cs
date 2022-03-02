using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnBltCtrl : MonoBehaviour
{
    Rigidbody2D bltRgdBdy;
    public float speed;
    public int dmg = 1;

    // Start is called before the first frame update
    void Awake()
    {
        bltRgdBdy = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        bltRgdBdy.AddForce(-Vector2.up * speed);
        Invoke("Disable", 5f);
    }

    private void Disable()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlyrCtrlr>().TkeDmg(dmg);
            Invoke("Disable", 0.001f);
        }
    }
}
