using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyrCtrlr : MonoBehaviour
{

    public float spd;
    Rigidbody2D plyrRgdBdy;
    float inputX;

    public LayerMask wlLyr;
    public float ryLngth;
    bool cnJmp;
    public float jmpHt;

    bool hurt;
    public float mxHlth;
    [SerializeField]
    float hlth;
    public float tmeBtwnHrt;
    float iframe;

    void Awake()
    {
        plyrRgdBdy = GetComponent<Rigidbody2D>();
        hlth = mxHlth;
        hurt = false;
        iframe = tmeBtwnHrt;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        if(inputX != 0)
        {
            plyrRgdBdy.AddForce(Vector2.right * inputX * spd * Time.deltaTime);
        }

        //Jump Condition
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, ryLngth, wlLyr);
        if(hit.collider != null)
        {
            cnJmp = true;
        }

        if(cnJmp && Input.GetKeyDown(KeyCode.Space))
        {
            plyrRgdBdy.AddForce(Vector2.up * jmpHt);
            cnJmp = false;
        }
        Debug.DrawRay(transform.position, Vector2.down * ryLngth);

        if(iframe > 0)
        {
            iframe -= Time.deltaTime;
        }


        //Damage Test
        if(!hurt && Input.GetKeyDown(KeyCode.LeftControl))
        {
            dmg(2);
        }
    }

    void dmg(float amt)
    {
        hlth -= amt;
        hurt = true;
        Invoke("ResetHurt", 0.2f);

        //Game Over
        if(hlth <= 0)
        {

        }

        iframe = tmeBtwnHrt;
    }

    void ResetHurt()
    {
        hurt = false;
    }
}
