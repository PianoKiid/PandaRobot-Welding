using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeldingRenderer : MonoBehaviour
{
    public GameObject instance;
    public GameObject TCP;

    private int Fixcount = 0;


    // Update is called once per frame
    void Update()
    {
        Fixcount++;


        if (Input.GetKey(KeyCode.D) == true)
        {
            Debug.Log("D");

            if (Fixcount % 10 == 0)
            {
                GameObject clone = Instantiate(instance);
                clone.transform.position = TCP.transform.position + new Vector3(-0.063f, -0.063f, 0.158f);
            }

        }

    }
}
