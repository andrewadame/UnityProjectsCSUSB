using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bsbllCtrlr : MonoBehaviour
{
    public float spd;
    Rigidbody2D bsbllRgdBdy;
    public float dmg;

    private void Awake()
    {
        bsbllRgdBdy = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        bsbllRgdBdy.AddForce(transform.up * spd);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlyrCtrlr>().dmg(dmg);

            //destroy baseball on hit
            Invoke("Disable", 0.001f);
        }

        if(collision.gameObject.CompareTag("Wall"))
        {
            Invoke("Disable", 0.001f);
        }
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
