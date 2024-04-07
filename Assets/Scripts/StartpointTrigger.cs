using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartpointTrigger : MonoBehaviour
{
    private GameObject Endpoint;
    public TargetController targetcontoller;

    void OnEnable()
    {
        Endpoint = transform.parent.GetChild(1).gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "TCP" && targetcontoller.Iswelding == true)
        {
            Endpoint.SetActive(true);
        }
    }
}
