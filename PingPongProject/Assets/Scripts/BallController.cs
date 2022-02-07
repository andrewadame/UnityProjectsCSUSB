using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;
    public float randomUp;

    Rigidbody2D ballRigidbody;

    GameController cont;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        cont = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        Invoke("PshBall", 1f);

    }

    private void PshBall()
    {
        int dir = Random.Range(0, 2);   //return 0, 1
        float x, y;
        if(dir == 0)
        {
            x = speed;
        }
        else
        {
            x = -speed;
        }

        y = Random.Range(-randomUp, randomUp);

        ballRigidbody.AddForce(new Vector2(x, y));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = ballRigidbody.velocity.x;
            vel.y = ballRigidbody.velocity.y / 2 + (collision.collider.attachedRigidbody.velocity.y / 2);

            ballRigidbody.velocity = vel;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {

            if(ballRigidbody.velocity.x > 0)
            {
                cont.Score(true);
            }
            else if (ballRigidbody.velocity.x < 0)
            {
                cont.Score(false);
            }

            ballRigidbody.velocity = Vector2.zero;
            transform.position = Vector3.zero;  // equivalent to Vector3(0,0,0)
            Invoke("PshBall", 2f);
        }
    }

}
