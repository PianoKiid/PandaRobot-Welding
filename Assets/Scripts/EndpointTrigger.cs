using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointTrigger : MonoBehaviour
{
    public bool IsTriggered;
    public TargetController targetcontoller;

    void OnEnable()
    {
        IsTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TCP" && targetcontoller.Iswelding == true)
        {
            IsTriggered = true;
        }
    }

    void OnDisable()
    {
        IsTriggered = false;
    }
}
