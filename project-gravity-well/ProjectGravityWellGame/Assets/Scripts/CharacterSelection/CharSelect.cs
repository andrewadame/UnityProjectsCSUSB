using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour
{

    [SerializeField] int color1, color2, color3, color4;

    [SerializeField] private AudioSource PayNSpray;

    private void OnTriggerEnter2D(Collider2D other) // changes the color based on what sprite the player touched
    {
        if(other.tag == "Player")
        {
            PlayerController thePlayer = other.GetComponent<PlayerController>();
            thePlayer.gameObject.GetComponent<SpriteRenderer>().color = new Color(color1, color2, color3, color4);
            PayNSpray.Play();
        }
    }
}
