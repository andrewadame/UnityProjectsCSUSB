using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoShellCtrlr : MonoBehaviour
{
    public float spd;
    Rigidbody2D bltRgdBdy;
    public float dmg;

    public float rad;
    public LayerMask enMsk;

    private void Awake()
    {
        bltRgdBdy = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        bltRgdBdy.AddForce(transform.up * spd);
        Invoke("Disable", 4f);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Disable()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, rad, enMsk);
            foreach(Collider2D col in hit)
            {
                col.GetComponent<EnCtrlr>().TkeDmg(dmg);
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rad);
    }
}
