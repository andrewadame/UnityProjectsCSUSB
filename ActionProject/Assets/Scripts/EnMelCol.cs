using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnMelCol : MonoBehaviour
{
    public float atk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlyrCtrlr>().Damage(atk);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlyrCtrlr>().Damage(atk);
        }
    }
}
