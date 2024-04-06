using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class CloneStopping : MonoBehaviour
{
    private int UpdateCount = 0;

    public GameObject Target_CloneClone;

    private bool latency = false;


    // Update is called once per frame
    void FixedUpdate()
    {

        UpdateCount++;

        if (latency == false)
        {
            PositionCloneClone();
        }

        if (UpdateCount == 500)
        {
            latency = true;
        }

        /*        if (UpdateCount == 550 || UpdateCount == 650)
                {
                    trclone = BasePosition[BasePosition.Count - 10];
                    Target_Clone.transform.position = trclone;
                }*/

        if (UpdateCount == 570)
        {
            latency = false;
        }


    }

    void PositionCloneClone()
    {

        Target_CloneClone.transform.position = transform.position;

    }

}