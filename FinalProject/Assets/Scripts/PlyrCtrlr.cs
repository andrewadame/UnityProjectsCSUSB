using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlyrCtrlr : MonoBehaviour
{
    Rigidbody2D plyrRgdBdy;
    Vector2 input;
    public float spd;
    public float dgeSpd;
    Vector2 dgeVec; //Dodge direction    

    Animator anim;
    SpriteRenderer rend;

    int lkDir = 0;  //0=down, 1=left/right, 2=up
    bool mvng = false;

    public float mxHlth;
    public float hlth;
    public Image htlhUI;

    public int mxMny;
    public int mny;
    public Text mnyTxt;

    public float attack;
    public int level = 1;
    public float exp;
    public float expToNxt;
    public AnimationCurve expCurve = new AnimationCurve();
    public Text expTxt;

    public float ifrmeTme = 0.6f;
    float iframe;
    public float dgeTme = 0.8f;
    float dge;

    public GameObject meleeCol;

    private void Awake()
    {
        plyrRgdBdy = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        expToNxt = CalcExp(level);
        for (int i = 1; i <= 30; i++)
        {
            expCurve.AddKey(i, CalcExp(i));
        }

        hlth = mxHlth;
        mny = mxMny;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (iframe > 0)
        {
            iframe -= Time.deltaTime;
        }
        if(dge > 0)
        {
            dge -= Time.deltaTime;
        }

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        plyrRgdBdy.AddForce(input * spd * Time.deltaTime);

        mvng = (input.x != 0 || input.y != 0);

        
        if (input.y < 0)
        {
            lkDir = 0;

            //Attack Down
            meleeCol.transform.localPosition = new Vector3(0, -0.16f, 0);
            meleeCol.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (input.x > 0)
        {
            lkDir = 1;

            //Attack Right
            rend.flipX = false;
            meleeCol.transform.localPosition = new Vector3(0.111f, -0.003f, 0);
            meleeCol.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (input.y > 0)
        {
            lkDir = 2;

            //Attack Up
            meleeCol.transform.localPosition = new Vector3(0, 0.16f, 0);
            meleeCol.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (input.x < 0)
        {
            lkDir = 1;

            //Attack Left
            rend.flipX = true;
            meleeCol.transform.localPosition = new Vector3(-0.111f, -0.003f, 0);
            meleeCol.transform.localScale = new Vector3(1, 1, 1);
        }
        

        anim.SetInteger("dir", lkDir);
        anim.SetBool("mov", mvng);


        //Dodge
        ///////////
        if (Input.GetKeyDown(KeyCode.F) && input != Vector2.zero)
        {
            Dodge();
        }
        ///////////


        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwgAtk();
            Debug.Log("Attack!");
        }

        //EXP TEXT
        if (Input.GetKeyDown(KeyCode.J))
        {
            AddExp(20);
        }

        htlhUI.fillAmount = hlth / mxHlth;
        mnyTxt.text = "Coins: " + mny.ToString();
        expTxt.text = "Level " + level.ToString() + " - Exp: " + exp.ToString() + "/" + expToNxt.ToString();

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
        if (hlth > mxHlth)
        {
            hlth = mxHlth;
        }
    }

    public void Dodge()
    {
        if (iframe <= 0 && dge <= 0)
        {
            dgeVec = input.normalized;
            iframe = ifrmeTme;
            dge = dgeTme;

            //Dodge!
            plyrRgdBdy.velocity = dgeVec.normalized * dgeSpd;
            Debug.Log("Dodge!");
        }
    }

    public void Damage(float amt)
    {
        if (iframe <= 0)
        {
            hlth -= amt;
            iframe = ifrmeTme;
            if (hlth <= 0)
            {
                Die();
            }
        }
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
        FindObjectOfType<GmeCtrlr>().gmeOvr = true;
        FindObjectOfType<GmeCtrlr>().gameOverUI.SetActive(true);
        Time.timeScale = 0;

    }

    public void AddMny(int amnt)
    {
        mny += amnt;
    }

    public float CalcExp(int level)
    {
        float expNded;
        expNded = level * 50f;
        return expNded;
    }

    public void AddExp(float amt)
    {
        exp += amt;

        if (exp >= expToNxt)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        exp -= expToNxt;
        attack = attack + 5f;
        spd = spd + 50f;
        mxHlth = mxHlth + 10f;
        Heal(mxHlth);
        expToNxt = CalcExp(level);
    }
}
