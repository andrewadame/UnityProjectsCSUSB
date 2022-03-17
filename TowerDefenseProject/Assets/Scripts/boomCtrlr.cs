using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomCtrlr : MonoBehaviour
{
    public AnimationClip clip;

    private void OnEnable()
    {
        Invoke("Disable", clip.length);
    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}
