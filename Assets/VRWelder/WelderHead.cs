using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelderHead : MonoBehaviour
{
    public bool contact = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "weldable")
        {
            contact = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "weldable")
        {
            contact = false;
        }
    }
}
