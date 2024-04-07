using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPointTrigger1 : MonoBehaviour
{
    public TargetController targetcontoller;

    public bool Isdelay1 = false;
    public float delaytime;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TCP" && targetcontoller.Iswelding == true)
        {
            Isdelay1 = true;
            Invoke("DelayRepair", delaytime);
            transform.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }

    void DelayRepair()
    {
        Isdelay1 = false;
    }
}
