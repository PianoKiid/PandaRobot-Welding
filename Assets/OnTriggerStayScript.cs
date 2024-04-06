using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OnTriggerStayScript : MonoBehaviour
{

    private MeshRenderer MeshRenderer;

    private void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();

        MeshRenderer.enabled = false;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "weldable")
        {
            MeshRenderer.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "weldable")
        {
            MeshRenderer.enabled = false;
        }
    }
}
