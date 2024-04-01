using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCPMovement : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    private float smoothSpeed = 10.125f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = Vector3.Lerp(target1.transform.position, target2.transform.position, smoothSpeed);
        transform.position = desiredPosition;

        transform.LookAt(target2);
    }
}
