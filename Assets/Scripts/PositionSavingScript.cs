using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class PositionSavingScript : MonoBehaviour
{
    private int UpdateCount = 0;
    Vector3 tr;
    Vector3 trclone;

    List<Vector3> BasePosition = new List<Vector3>();

    public int LatencyCount = 1;

    public GameObject Target_Clone;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateCount++;

        tr = transform.position;
        BasePosition.Add(tr);

        PositionClone();
    }

    void PositionClone()
    {

        if (UpdateCount <= LatencyCount + 1)
        {
            trclone = BasePosition[0];
        }

        if (UpdateCount >= LatencyCount + 1)
        {
            trclone =  BasePosition[BasePosition.Count - LatencyCount];
        }

        Target_Clone.transform.position = trclone;
    }

}
