using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class PositionSavingScript : MonoBehaviour
{
    public int UpdateCount = 0;
    Vector3 tr;
    Vector3 trclone;

    List<Vector3> BasePosition = new List<Vector3>();

    public int StartCount = 30;

    public GameObject Target_Clone;

    private bool latency = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateCount++;
        Debug.Log(UpdateCount);

        tr = transform.position;
        BasePosition.Add(tr);

        if (latency == false)
        {
            PositionClone();
        }

        if (UpdateCount == 500)
        {
            latency = true;
        }

        if (UpdateCount == 550 || UpdateCount == 650)
        {
            trclone = BasePosition[BasePosition.Count - 10];
            Target_Clone.transform.position = trclone;
        }

        if (UpdateCount == 720)
        {
            latency = false;
        }


    }

    void PositionClone()
    {

        if (UpdateCount <= StartCount + 1)
        {
            trclone = BasePosition[0];
        }

        if (UpdateCount >= StartCount + 1)
        {
            trclone =  BasePosition[BasePosition.Count - StartCount];
        }

        Target_Clone.transform.position = trclone;
    }

}
