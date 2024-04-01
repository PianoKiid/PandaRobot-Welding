using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class Welder : MonoBehaviour
{
    public GameObject Cube;
    public GameObject LeftController;
    public float yoffset;
    public GameObject welderHead;
    public GameObject weldInstance;
    public GameObject weldholder;
    public WelderHead wH;
    public OVRInputProvider inputProvider;
    public bool waiting = false;
    // Update is called once per frame
    void Update()
    {
        if (inputProvider.left_primaryButton.Up)
        {
            SetCube();
        }
        if (waiting)
        {
            return;
        }
        
        if (wH.contact)
        {
            if (inputProvider.right_trigger.Pressed)
            {
                CreateNewWeld();
            }
            //can weld


        }



    }
    IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(0.1f);
        waiting = false;
    }
    void CreateNewWeld()
    {
        var instance =  Instantiate(weldInstance);
        instance.transform.parent = weldholder.transform;
        instance.transform.position = welderHead.transform.position + new Vector3(0, yoffset,0);
        StartCoroutine(Wait());
    }
    void SetCube()
    {
        var instance = Instantiate(Cube);
        instance.transform.position = LeftController.transform.position - new Vector3(0,0.525f,0);

    }
}
