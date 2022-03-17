using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BseTwr : MonoBehaviour
{
    public float StSpd;
    public float CnRot;
    public Transform trgt;
    public float atkRng;

    public Transform child;

    protected float cldwn;
    public GameObject blt;

    public GameObject[] bltSpwnPos;

    public float cost;

    public GameObject flsh;

    protected AudioSource srce;

    private void Awake()
    {
        srce = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GetComponent<CircleCollider2D>().radius = atkRng;
        cldwn = StSpd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && trgt == null)
        {
            trgt = collision.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && trgt == null)
        {
            trgt = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && trgt == collision.transform)
        {
            trgt = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trgt != null)
        {
            //Debug.Log(trgt.gameObject);
            Vector3 dir = trgt.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * CnRot);
            if (cldwn > 0)
            {
                cldwn -= Time.deltaTime;
            }
            else
            {
                Shoot();
            }
        }
    }

    public virtual void Shoot()
    {
        
    }

    private void LateUpdate()
    {
        child.transform.rotation = Quaternion.identity;
    }
}
