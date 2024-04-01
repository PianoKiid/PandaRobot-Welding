using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class WeldingAnimation2 : MonoBehaviour
{
    public float yoffset;
    public GameObject welderHead;
    public GameObject weldInstance;
    public GameObject weldholder;
    public WelderHead wH;

    public ActionBasedController rightHandController;
    public InputActionProperty activateAction; // For the welding trigger

    private bool waiting = false;
    private bool triggerPressed = false; // Track if the trigger is being pressed

    private void OnEnable()
    {
        activateAction.action.performed += _ => StartWelding();
        activateAction.action.canceled += _ => StopWelding();
    }

    private void OnDisable()
    {
        activateAction.action.performed -= _ => StartWelding();
        activateAction.action.canceled -= _ => StopWelding();
    }

    private void Update()
    {
        //if (triggerPressed && !waiting && wH.contact)
        if (triggerPressed && !waiting)
        {
            CreateNewWeld();
        }
    }

    IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(0.1f); // Adjust the wait time as needed for continuous welding effect
        waiting = false;
    }

    void StartWelding()
    {
        triggerPressed = true;
    }

    void StopWelding()
    {
        triggerPressed = false;
    }

    void CreateNewWeld()
    {
        var instance = Instantiate(weldInstance, weldholder.transform);
        instance.transform.position = welderHead.transform.position + new Vector3(0, yoffset, 0);
        StartCoroutine(Wait());
    }
}
