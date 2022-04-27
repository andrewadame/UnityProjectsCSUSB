using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCtrlr : MonoBehaviour
{
    Rigidbody2D crRgdBdy;
    public float spd;
    public float bckSpd;
    public float rtSpd;
    Vector2 input;

    public string inputXNme;
    public string inputYNme;

    public GameObject cam;
    public int num;

    [SerializeField]
    int crntLp = 0;
    GmeCtrlr cont;

    float cools;
    public float slckTmr;
    public bool slicked = false;
    public float slickRot;
    Vector2 slickDir;

    public float rgDrg;
    public float slkDrg;
    float crntDrg;
    public float drgLrp;

    public bool htChckPnts = false;

    private void OnEnable()
    {
        //Create Cam and follow
        GameObject c = Instantiate(cam, transform.position, Quaternion.identity);

        c.GetComponent<CmCtrlr>().trgt = transform;
        if (num == 1)
        {
            c.GetComponent<Camera>().rect = new Rect(new Vector2(0f, 0f), new Vector2(0.5f, 1f));
        }
        else
        {
            c.GetComponent<Camera>().rect = new Rect(new Vector2(0.5f, 0f), new Vector2(0.5f, 1f));
        }

        crntLp = 0;
        crntDrg = rgDrg;
    }

    private void Awake()
    {
        crRgdBdy = GetComponent<Rigidbody2D>();
        cont = FindObjectOfType<GmeCtrlr>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cont.strtd && !slicked)
        {
            input = new Vector2(Input.GetAxis(inputXNme), Input.GetAxis(inputYNme));
            if (input.x != 0)
            {
                transform.Rotate(0, 0, -rtSpd * Time.deltaTime * input.x);
            }

            if (input.y > 0)
            {
                crRgdBdy.AddForce(transform.up * input.y * spd * Time.deltaTime);
            }

            if (input.y < 0)
            {
                crRgdBdy.AddForce(transform.up * input.y * bckSpd * Time.deltaTime);
            }
        }
        if(slicked)
        {
            crRgdBdy.AddForce(slickDir * bckSpd * Time.deltaTime);
            transform.Rotate(0, 0, slickRot * Time.deltaTime);

            if(cools <= 0)
            {
                slicked = false;
            }
        }

        if(cools > 0)
        {
            cools -= Time.deltaTime;
        }

        crntDrg = slicked ? slkDrg : rgDrg;
        crRgdBdy.drag = Mathf.Lerp(crRgdBdy.drag, crntDrg, drgLrp * Time.deltaTime) ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal") && htChckPnts)
        {
            crntLp++;
            if (crntLp >= cont.laps)
            {
                cont.EndGame(num);
            }

            htChckPnts = false;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            slickDir = transform.up;
            cools = slckTmr;
            slicked = true;
        }

        if(collision.gameObject.CompareTag("Checkpoint"))
        {
            htChckPnts = true;
        }

    }
}
