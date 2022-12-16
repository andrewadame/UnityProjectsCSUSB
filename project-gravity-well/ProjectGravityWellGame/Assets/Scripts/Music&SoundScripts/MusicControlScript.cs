using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlScript : MonoBehaviour
{
    public static MusicControlScript instance;

    // Update is called once per frame
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
