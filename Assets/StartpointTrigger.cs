using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartpointTrigger : MonoBehaviour
{
    private GameObject Endpoint;

    void OnEnable()
    {
        Endpoint = transform.parent.GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TCP")
        {
            Endpoint.SetActive(true);
        }
    }
}
