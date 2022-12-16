using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnMelCol : MonoBehaviour
{
    PlyrCtrlr plyr;

    private void Awake()
    {
        plyr = FindObjectOfType<PlyrCtrlr>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If hitbox hits enemy, damage
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlyrCtrlr>().Damage(plyr.attack);
            Debug.Log("Player Damaged!");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlyrCtrlr>().Damage(plyr.attack);
        }
    }
}
