using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyrCtrlr : MonoBehaviour
{

    [Header("Starting states")]
    public float speed;
    Vector2 input;
    Rigidbody2D plyrRgdBdy;

    [Header("Shooting")]
    public GameObject blt;
    public GameObject[] bltSpwnPos;
    private float cools;
    public float TmeBtwnShts;

    [Header("Health")]
    public int maxHlth = 10;
    [SerializeField]
    private int Hlth;

    public GameObject HlthImg;
    public GameObject hlthPrnt;
    public float tmeBtwnHrt = 0.3f;
    float iframe;

    public GameObject flsh;

    // Start is called before the first frame update
    void Start()
    {
        plyrRgdBdy = GetComponent<Rigidbody2D>();
        cools = TmeBtwnShts;
        Hlth = maxHlth;
        iframe = tmeBtwnHrt;
        for(int i = 0; i < Hlth - 1; i++)
        {
            AddHrt();
        }
    }

    void AddHrt()
    {
        GameObject hrt = Instantiate(HlthImg);
        hrt.transform.SetParent(hlthPrnt.transform);
    }

    void RmveHrt(int n)
    {
        if(hlthPrnt.transform.childCount > 0)
        {
            if(hlthPrnt.transform.childCount < n)
            {
                n = hlthPrnt.transform.childCount;
            }

            for(int i = 0; i < n; i ++)
            {
                Destroy(hlthPrnt.transform.GetChild(0).gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        plyrRgdBdy.AddForce(input * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Space) && cools <= 0)
        {
            Shoot();
        }

        if (cools > 0)
        {
            cools -= Time.deltaTime;
        }
        
        if(iframe > 0)
        {
            iframe -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        for(int i = 0; i < bltSpwnPos.Length; i++)
        {
            Instantiate(blt, bltSpwnPos[i].transform.position, Quaternion.identity);
        }

        Instantiate(flsh, transform.position, Quaternion.Euler(0, 0, 0));

        cools = TmeBtwnShts;
    }

    public void TkeDmg(int dmg)
    {
        if (iframe <= 0)
        {
            RmveHrt(dmg);
            Hlth = Hlth - dmg;
            if (Hlth <= 0)
            {
                GmeOvr();
            }
            iframe = tmeBtwnHrt;
        }
    }

    void GmeOvr()
    {
        FindObjectOfType<GmeCtrlr>().gmeOvr = true;
        FindObjectOfType<GmeCtrlr>().gameOverUI.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TkeDmg(1);
            Destroy(collision.gameObject);
        }
    }
}
