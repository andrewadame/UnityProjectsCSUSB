using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlyrCtrlr : MonoBehaviour
{

    public float spd;
    Rigidbody2D plyrRgdBdy;
    float inputX;

    public LayerMask wlLyr;
    public float ryLngth;
    [SerializeField]
    bool cnJmp;
    public float jmpHt;

    bool hurt;
    public float mxHlth;
    [SerializeField]
    float hlth;
    public float tmeBtwnHrt;
    float iframe;

    Animator anim;

    SpriteRenderer rend;

    [SerializeField]
    int coins;

    public Image hlthImg;
    public Text coinsTxt;

    public GameObject GmeOvrUI;
    bool gmeOvr;

    void Awake()
    {
        plyrRgdBdy = GetComponent<Rigidbody2D>();
        hlth = mxHlth;
        hurt = false;
        iframe = tmeBtwnHrt;
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        coins = 0;
        gmeOvr = false;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        if(inputX != 0)
        {
            plyrRgdBdy.AddForce(Vector2.right * inputX * spd * Time.deltaTime);
        }

        rend.flipX = (inputX < 0);

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
            dmg(1);
        }

        //UI
        hlthImg.fillAmount = Mathf.Lerp(hlthImg.fillAmount, hlth / mxHlth, Time.deltaTime * 10f);
        coinsTxt.text = coins.ToString();

        //Animation
        anim.SetBool("Mvng", inputX != 0);
        anim.SetBool("CnJmp", cnJmp);
        anim.SetBool("Hrt", hurt);

        if(gmeOvr && Input.anyKeyDown)
        {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1f;
        }    
    }

    public void dmg(float amt)
    {
        if (iframe < 0)
        {
            hlth -= amt;
            hurt = true;
            Invoke("ResetHurt", 0.2f);

            //Game Over
            if (hlth <= 0)
            {
                GameOver();

            }

            iframe = tmeBtwnHrt;
        }
    }

    private void GameOver()
    {
        gmeOvr = true;
        GmeOvrUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void ResetHurt()
    {
        hurt = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins++;

            //Delete
            Destroy(collision.gameObject);

            /*Disable
            collision.gameObject.SetActive(false);
            */
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If player lands on top of enemy, do damage to enemy
        if(collision.gameObject.CompareTag("Enemy") && plyrRgdBdy.velocity.y < 0)
        {
            float bndsY = collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.y/2;

            //If player on enemy side, add force
            if(transform.position.y > collision.gameObject.transform.position.y + bndsY)
            {
                plyrRgdBdy.AddForceAtPosition(-plyrRgdBdy.velocity.normalized * jmpHt / 2f, plyrRgdBdy.position);
                collision.gameObject.GetComponent<EnCtrlr>().Damage(5f);
            }
        }
    }
}
