using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float x, y;
    public float speed;

    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //transform.position += new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0); // x += 2; x = x + 2

        myRigidbody2D.AddForce(new Vector2(x * speed * Time.deltaTime, y * speed * Time.deltaTime));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D " + collision.gameObject.name + " " + this.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D " + collision.gameObject.name + " " + this.name);

        if (collision.gameObject.name == "WallL")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "WallR")
        {
            Destroy(gameObject);
        }
    }
}
