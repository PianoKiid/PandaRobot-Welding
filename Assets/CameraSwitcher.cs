using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CameraSwitcher : MonoBehaviour
{
    public Camera Main_Camera;
    /*public Camera TCP_Camera;*/

    public GameObject TCP_fingers;
    public GameObject TCP;

    public TrackedPoseDriver Main_TPD;
    /*public TrackedPoseDriver TCP_TPD;*/

    private float smoothspeed = 0.05f;

    private bool Mainmode = true;
    private bool TCPmode = false;

    private Vector3 LatePosition;

    public CameraMovement cameramovement;

    void Start()
    {
        Main_Camera.enabled = true;

        Main_TPD.enabled = true;

        Mainmode = true;

        TCPmode = false;
        
    }

    void Update()
    {
        Vector3 desiredPosition = Vector3.Lerp(TCP_fingers.transform.position, TCP.transform.position, smoothspeed);

        if (Input.GetKeyDown(KeyCode.C))
        {

            Mainmode = !Mainmode;
            TCPmode = !TCPmode;

            if (Mainmode == true)
            {
                cameramovement.enabled = true;

            }

            if (TCPmode == true)
            {
                cameramovement.enabled = false;

                Main_TPD.enabled = false;

                Main_Camera.transform.position = TCP.transform.position - 0.1f * desiredPosition;

                Main_Camera.transform.LookAt(TCP.transform);

                Main_TPD.enabled = true;

            }
        }
    }

/*    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Main_TPD.enabled = !Main_TPD.enabled;
        }
    }*/


    /*    void Start()
        {
            Main_Camera.enabled = true;
            TCP_Camera.enabled = false;
            Main_TPD.enabled = true;
            TCP_TPD.enabled = false;

            Debug.Log(TCP_fingers.transform.position);
            Debug.Log(TCP.transform.position);
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Main_Camera.enabled = !Main_Camera.enabled;
                TCP_Camera.enabled = !TCP_Camera.enabled;

                if (Main_Camera.enabled == true)
                {
                    Main_Camera.transform.position = TCP_Camera.transform.position;
                    Main_TPD.enabled = true;
                    TCP_TPD.enabled = false;
                }

                if (TCP_Camera.enabled == true)
                {
                    Vector3 desiredPosition = Vector3.Lerp(TCP_fingers.transform.position, TCP.transform.position, smoothspeed);
                    TCP_Camera.transform.position = TCP.transform.position - 0.1f*desiredPosition;

                    TCP_Camera.transform.LookAt(TCP.transform);
                }
            }   
        }

        void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                Main_TPD.enabled = !Main_TPD.enabled;
                TCP_TPD.enabled = !TCP_TPD.enabled;
            }

        }*/
}
