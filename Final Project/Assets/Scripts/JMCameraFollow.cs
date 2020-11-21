
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMCameraFollow : MonoBehaviour
{
    public GameObject target;

    public float followSpeed = 0.5f;
    public bool followYaxis = false;



    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;
        targetPos.z = transform.position.z;
        if (!followYaxis)
            targetPos.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed);

    }
}
