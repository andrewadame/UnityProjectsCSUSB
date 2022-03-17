using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BltCtrlr : MonoBehaviour
{

    public float spd;
    Rigidbody2D bltRgdBdy;
    public float dmg;

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
            collision.GetComponent<EnCtrlr>().TkeDmg(dmg);

            //destroy bullet on hit
            Destroy(gameObject);
        }
    }
}
