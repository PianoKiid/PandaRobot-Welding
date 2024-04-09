using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPointTrigger2 : MonoBehaviour
{
    public TargetController targetcontoller;

    public bool Isdelay1 = false;
    public float delaytime;
    public PositionSavingScript aa;

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
        aa.LatencyCount = 60;
        Isdelay1 = false;
    }
}
