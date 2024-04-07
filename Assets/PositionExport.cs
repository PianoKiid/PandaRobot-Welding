using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class PositionExport : MonoBehaviour
{
    private string m_FilePath = @"C:\Users\VR504-L\Desktop\Panda\Example.txt";

    private StreamWriter sw;

    private Vector3 position;

    public GameObject target;

    void Start()
    {
        sw = File.CreateText(m_FilePath);

        sw.WriteLine("Jimin");
        sw.WriteLine("I");
        sw.WriteLine("Loveyou");
    }

    void FixedUpdate()
    {
        position = target.transform.position;

        sw.WriteLine("{0}, {1}, {2}", position.x, position.y, position.z);
    }

    void OnApplicationQuit()
    {

        sw.Close();

    }
}
