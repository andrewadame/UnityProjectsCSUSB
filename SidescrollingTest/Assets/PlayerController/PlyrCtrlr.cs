using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyrCtrlr : MonoBehaviour
{
    private Rigidbody2D plyrRgdBdy;

    //Player Movement
    public float plyrSpd;

    //Gravity
    private float gravAmt;

    //Jump Dir
    private float jmpDir;

    void Awake()
    {
        plyrRgdBdy = GetComponent<Rigidbody2D>();
        gravAmt = -9.8f;
        jmpDir = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        plyrRgdBdy.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * plyrSpd, plyrRgdBdy.velocity.y);

        //Jump
        if(Input.GetKey(KeyCode.Space))
        {
            plyrRgdBdy.velocity = new Vector2(plyrRgdBdy.velocity.x, plyrSpd) * jmpDir;
        }

    }

    //On touch line, switch gravity
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GravSw"))
        {
            Debug.Log("Switch!");
            gravAmt = gravAmt * -1;
            jmpDir = jmpDir * -1;
            Physics2D.gravity = new Vector2(0, gravAmt);
        }
    }

}
