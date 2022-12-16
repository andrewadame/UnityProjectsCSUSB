using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrlr : MonoBehaviour
{
    public Transform trgt;
    public float lrpSpd;

    Vector3 tempPos;
    [SerializeField]
    float minX, minY, maxX, maxY;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (trgt == null) return;
        tempPos = trgt.position;
        tempPos.z = -10;

        
        //MIN
        if (trgt.position.x < minX)
        {
            tempPos.x = minX;
        }
        if (trgt.position.y < minY)
        {
            tempPos.y = minY;
        }

        //MAX
        if (trgt.position.x > maxX)
        {
            tempPos.x = maxX;
        }
        if (trgt.position.y > maxY)
        {
            tempPos.y = maxY;
        }
        
        transform.position = Vector3.Lerp(transform.position, tempPos, lrpSpd * Time.deltaTime);
    }
}
