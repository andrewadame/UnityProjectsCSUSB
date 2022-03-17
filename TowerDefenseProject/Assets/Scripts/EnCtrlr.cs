using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnCtrlr : MonoBehaviour
{

    Rigidbody2D EnRgdBdy;
    public float spd;
    public float mxHlth;

    [SerializeField]
    float hlth;

    Transform trgt;
    public int crntWypt;
    GmeCtrlr cont;
    public float rotSpd;

    float dist;

    bool canMove = true;

    public float dmg;

    public float drpMny;

    public GameObject boom;

    private void Awake()
    {
        EnRgdBdy = GetComponent<Rigidbody2D>();
        cont = FindObjectOfType<GmeCtrlr>();
    }


    private void OnEnable()
    {
        hlth = mxHlth;

        crntWypt = 0;
        trgt = cont.waypoints[crntWypt];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = trgt.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotSpd);

        if (canMove)
        {
            EnRgdBdy.AddForce(transform.up * spd * Time.deltaTime);
        }

        dist = Vector2.Distance(transform.position, trgt.position);

        if (dist <= 0.05f)
        {
            if (crntWypt < cont.waypoints.Length - 1)   //still have waypoints, not last waypoint
            {
                canMove = false;
                Invoke("CanMove", 0.5f);
                crntWypt++;
                trgt = cont.waypoints[crntWypt];
            }
            else                                        //last waypoint
            {
                cont.TakeDamage(dmg);
                Destroy(gameObject);
            }
        }

    }

    void CanMove()
    {
        canMove = true;
    }

    public void TkeDmg(float dmge)
    {
        hlth -= dmg;
        if(hlth <= 0)
        {
            cont.GveMny(drpMny);
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        //Debug.Log("Enemy Take Damage");
    }
}
