using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public bool Plyer1;
    public float speed;
    int leftUp, rightUp;
    Rigidbody2D rigidbody;
    

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Plyer1)
        {
            if (Input.GetKey(KeyCode.W))
                leftUp = 1;
            else if (Input.GetKey(KeyCode.S))
                leftUp = -1;
            else
                leftUp = 0;

            // When not pressing key, stop moving
            if (leftUp == 0)
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.x);

            rigidbody.AddForce(Vector2.up * leftUp * speed * Time.deltaTime);  //(0.1) * 1 * speed * 0.003
           //(new Vector2(0, leftUp * speed * Time.deltaTime))                   (0 * 1 * speed * 0.03, 1 * 1 * speed * 0.03)

        }
        else   //Plyer2
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rightUp = 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                rightUp = -1;
            else
                rightUp = 0;

            if (rightUp == 0)
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.x);

            rigidbody.AddForce(Vector2.up * rightUp * speed * Time.deltaTime);

        }
        
    }
}
