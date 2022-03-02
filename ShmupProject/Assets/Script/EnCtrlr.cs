using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnCtrlr : MonoBehaviour
{

    Rigidbody2D enemyRgdBdy;
    PlyrCtrlr Plyr;
    public float xSpeed, ySpeed;

    public GameObject blt;
    public float tmeBtwnAtckLw = 0.5f;
    public float tmeBtwnAttckHi = 2f;

    float attckCls;

    public int maxEnHlth = 2;
    private int EnHlth;

    GmeCtrlr cont;
    public int amount;
    Vector2 bounds;

    public GameObject explsn;

    // Start is called before the first frame update
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        enemyRgdBdy = GetComponent<Rigidbody2D>();
        Plyr = FindObjectOfType<PlyrCtrlr>();

        attckCls = Random.Range(tmeBtwnAtckLw, tmeBtwnAttckHi);

        EnHlth = maxEnHlth;
        cont = FindObjectOfType<GmeCtrlr>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0f;
        if (Plyr != null)
        {
            if (Plyr.transform.position.x > transform.position.x) //enemy go left
            {
                x = xSpeed;
            }
            else if (Plyr.transform.position.x < transform.position.x) //enemy go right
            {
                x = -xSpeed;
            }
        }

        enemyRgdBdy.AddForce(new Vector2(x, -ySpeed) * Time.deltaTime);

        if (attckCls > 0)
        {
            attckCls -= Time.deltaTime;
        }
        else
        {
            Attck();
        }

        if(transform.position.y < -bounds.y)
        {
            cont.AddScre(-amount);
            Destroy(gameObject);
        }
    }

    void Attck()
    {
        Instantiate(blt, transform.position, transform.rotation);
        attckCls = Random.Range(tmeBtwnAtckLw, tmeBtwnAttckHi);
    }

    public void TkeDmg(int dmg)
    {
        EnHlth -= dmg;
        if(EnHlth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        cont.AddScre(amount);
        Instantiate(explsn, transform.position, Quaternion.Euler(0,0,0));
        Destroy(gameObject);
    }
}
