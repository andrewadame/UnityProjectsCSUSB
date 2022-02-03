using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed;

    // FixedUpdate is called on every frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y,-10), lerpSpeed * Time.fixedDeltaTime);

    }
}
