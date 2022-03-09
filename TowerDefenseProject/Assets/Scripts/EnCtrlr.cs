using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnCtrlr : MonoBehaviour
{

    Rigidbody2D EnRgdBdy;
    public float spd;
    public float mxHlth;
    float hlth;

    private void Awake()
    {
        EnRgdBdy = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        hlth = mxHlth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TkeDmg(float dmge)
    {
        Debug.Log("Enemy Take Damage");
    }
}
