using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    Rigidbody2D ballRigidbody;
    public float speed;
    public float randomUp;

    Vector3 startPosition;

    GameController cont;

    //Audio
    private AudioSource source;

    [SerializeField]
    private AudioClip Plyr;
    [SerializeField]
    private AudioClip Brk;
    [SerializeField]
    private AudioClip Gl;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        cont = FindObjectOfType<GameController>();

        //Get Audio
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Invoke("PshBall", 1f);
    }

    private void PshBall()
    {
        int dir = Random.Range(0, 1);   // 0, 1
        float x;
        if (dir == 0)   // right
        {
            x = speed;
        }
        else            //left
        {
            x = -speed;
        }

        ballRigidbody.AddForce(new Vector2(x, -randomUp));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision gameObject: " + collision.gameObject.name);
        Debug.Log("gameObject: " + gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel;
            vel.y = ballRigidbody.velocity.y;
            vel.x = ballRigidbody.velocity.x / 2 * collision.collider.attachedRigidbody.velocity.x / 2;
            ballRigidbody.velocity = vel;


            //Allow player slight control of ball bounce direction
            //Launches in direction in which paddle is moving if hit
            //Helps keep ball froms stagnation
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                ballRigidbody.AddForce(-collision.contacts[0].normal
            + new Vector2(-50, 0));
            }

            if(Input.GetKey(KeyCode.RightArrow))
            {
                ballRigidbody.AddForce(-collision.contacts[0].normal
            + new Vector2(50, 0));
            }

            //Play Png1 Sound
            source.clip = Plyr;
            source.Play();

        }

        if (collision.gameObject.CompareTag("Brick"))
        {
            cont.HitBrick();
            Destroy(collision.gameObject);

            //Play Png2 Sound
            source.clip = Brk;
            source.Play();

        }

        //Keeps ball from stagnation
        if (collision.gameObject.CompareTag("Wall"))
        {
            ballRigidbody.AddForce(-collision.contacts[0].normal
            + new Vector2(Random.Range(-20, 20), Random.Range(-20, 20)));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            cont.LoseLife();
            ballRigidbody.velocity = Vector2.zero;
            transform.position = startPosition;
            Invoke("PshBall", 2f);

            //Play Png3 Sound
            source.clip = Gl;
            source.Play();
        }

    }
}
