using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{

    [SerializeField] private AudioSource Hover;

    [SerializeField] private AudioSource onClick;

    public void HoverSound() 
    {
        Hover.Play();
    }
    
    public void OnClick() 
    {
        onClick.Play();
    }
}
