using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnCtrlr : MonoBehaviour
{
    public float mxHp;
    [SerializeField]
    float hp;
    public float exp;
    public int mny;

    PlyrCtrlr plyr;
    public float iframeTme = 0.3f;
    float iframe;

    public enum enState {chase, atk};
    public enState crntState;

    Animator anim;
    Rigidbody2D enRgdBdy;
    GameCtrlr cont;

    public float tmeBtwnAtk = 1f;
    float cools;

    public float spd;
    int dir;
    SpriteRenderer rend;
    public float atkRng;
    float dist;

    public GameObject meleeCol;

    private void Awake()
    {
        plyr = FindObjectOfType<PlyrCtrlr>();
        cont = FindObjectOfType<GameCtrlr>();
        anim = GetComponent<Animator>();
        enRgdBdy = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        
        hp = mxHp;
        iframe = iframeTme;
        crntState = enState.chase;
    }

    public void Dmg(float amt)
    {
        if (iframe <= 0)
        {
            hp -= amt;

            if (hp <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
        plyr.AddExp(exp);
        plyr.AddMny(mny);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(iframe > 0)
        {
            iframe -= Time.deltaTime;
        }
        if(cools > 0)
        {
            cools -= Time.deltaTime;
        }

        switch (crntState)
        {
            case (enState.chase):
                Chase();
                break;
            case (enState.atk):
                Attack();
                break;
        }
        anim.SetInteger("dir", dir);
    }

    void Chase()
    {
        dist = Vector2.Distance(transform.position, plyr.transform.position);

        if (plyr.transform.position.y < transform.position.y)
        {
            dir = 0;
            meleeCol.transform.localPosition = new Vector3(0, -0.311f, 0);
            meleeCol.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (plyr.transform.position.x > transform.position.x)
        {
            dir = 1;
            rend.flipX = false;
            meleeCol.transform.localPosition = new Vector3(0.3f, 0.2f, 0);
            meleeCol.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (plyr.transform.position.x < transform.position.x)
        {
            dir = 1;
            rend.flipX = true;
            meleeCol.transform.localPosition = new Vector3(-0.3f, 0.2f, 0);
            meleeCol.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (plyr.transform.position.y > transform.position.y)
        {
            dir = 2;
            meleeCol.transform.localPosition = new Vector3(0, 0.311f, 0);
            meleeCol.transform.localScale = new Vector3(1, 1, 1);
        }

        if (dist > atkRng)
        {
            Vector3 direction = plyr.transform.position - transform.position;
            enRgdBdy.AddForce(direction * spd * Time.deltaTime);
        }
        else
        {
            if(cools <= 0)
            {
                crntState = enState.atk;
            }
        }
    }

    void Attack()
    {
        anim.SetTrigger("atk");
        cools = tmeBtwnAtk;
        crntState = enState.chase;
        
    }
}
