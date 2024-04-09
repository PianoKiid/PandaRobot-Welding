using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneStopping3 : MonoBehaviour
{
    private int UpdateCount = 0;

    public GameObject Target_CloneClone;

    private SceneManager SceneManager;

    public GameObject DelayPoint1;

    private bool latency = false;

    void Start()
    {
        SceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        UpdateCount++;

        if (DelayPoint1.GetComponent<DelayPointTrigger3>().Isdelay1 == false)
        {
            latency = false;
        }

        if (DelayPoint1.GetComponent<DelayPointTrigger3>().Isdelay1 == true)
        {
            latency = true;
        }

        if (latency == false)
        {
            PositionCloneClone();
        }

        Debug.Log(latency);


    }

    void PositionCloneClone()
    {

        Target_CloneClone.transform.position = transform.position;

    }
}
