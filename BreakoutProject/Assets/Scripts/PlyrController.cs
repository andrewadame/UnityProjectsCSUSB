using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyrController : MonoBehaviour
{

    Rigidbody2D plyrRigidBody;

    float input;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        plyrRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            input = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            input = 1;
        else
            input = 0;

        if(input == 0)
            plyrRigidBody.velocity = new Vector2(0, plyrRigidBody.velocity.x);

        plyrRigidBody.AddForce(Vector2.right * input * speed * Time.deltaTime);

    }
}
