using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyrCtrlr : MonoBehaviour
{
    Rigidbody2D plyrRgdBdy;
    Vector2 input;
    public float spd;

    Animator anim;
    SpriteRenderer rend;

    int lkDir = 0;  //0=down, 1=left/right, 2=up
    bool mvng = false;

    public float mxHlth;
    public float hlth;


    private void Awake()
    {
        plyrRgdBdy = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        hlth = mxHlth;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        plyrRgdBdy.AddForce(input * spd * Time.deltaTime);

        mvng = (input.x != 0 || input.y != 0);

        if(input.y > 0)
        {
            lkDir = 2;
        }
        else if(input.y < 0)
        {
            lkDir = 0;
        }

        if (input.x > 0)
        {
            lkDir = 1;
            rend.flipX = false;
        }
        else if (input.x < 0)
        {
            lkDir = 1;
            rend.flipX = true;
        }

        anim.SetInteger("dir", lkDir);
        anim.SetBool("mov", mvng);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwgAtk();
        }
    }

    public void SwgAtk()
    {
        anim.SetBool("atk", true);
        Invoke("RstAtk", 0.1f);
    }

    void RstAtk()
    {
        anim.SetBool("atk", false);
    }

    public void Heal(float amt)
    {
        hlth += amt;
        if(hlth > mxHlth)
        {
            hlth = mxHlth;
        }
    }

    public void Damage(float amt)
    {
        hlth -= amt;

        /* 
        if(hlth <= 0)
        {
            Die();
        }
        */
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
