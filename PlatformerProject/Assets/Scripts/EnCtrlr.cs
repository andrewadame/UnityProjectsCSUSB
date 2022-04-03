using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnCtrlr : MonoBehaviour
{
    public float mxHlth;
    protected float hlth;
    public Image hlthImg;

    public float spd;
    public float rnSpd;
    public float chsRng;
    public float atkRng;
    public enum enStes {move, chase, attack};
    public enStes crntSte = enStes.move;
    protected Rigidbody2D enRgdBdy;

    public LayerMask wlLyr;
    public float ryLgth;

    public int dir; //right = 1, left = -1

    protected SpriteRenderer rend;

    protected float dist;
    protected PlyrCtrlr plyr;

    private void OnEnable()
    {
        hlth = mxHlth;
        //if Random.value is >= 0.5, then (?) right. Otherwise, left.
        dir = (Random.value >= 0.5f) ? 1 : -1;
    }

    private void Awake()
    {
        enRgdBdy = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        plyr = FindObjectOfType<PlyrCtrlr>();
    }

    public virtual void Move()
    {

    }

    public virtual void Chase()
    {

    }

    public virtual void Attack()
    {

    }

    public virtual void Damage(float amnt)
    {

    }

    public virtual void Die()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rend.flipX = (dir == -1);

        //States of Enemy
        switch(crntSte)
        {
            case enStes.move:
                    Move();
            break;

            case enStes.chase:
                    Chase();
            break;

            case enStes.attack:
                    Attack();
            break;
        }

        hlthImg.fillAmount = Mathf.Lerp(hlthImg.fillAmount, hlth / mxHlth, Time.deltaTime * 10f);
    }
}
