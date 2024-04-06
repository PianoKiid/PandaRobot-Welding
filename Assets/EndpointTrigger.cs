using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointTrigger : MonoBehaviour
{
    public bool IsTriggered;

    void OnEnable()
    {
        IsTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TCP")
        {
            IsTriggered = true;
        }
    }

    void OnDisable()
    {
        IsTriggered = false;
    }
}
