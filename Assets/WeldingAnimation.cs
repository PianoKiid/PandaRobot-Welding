using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class WeldingAnimation : MonoBehaviour
{
 
    public float yoffset;
    public GameObject welderHead;
    public GameObject weldInstance;
    public GameObject weldholder;
    public WelderHead wH;

    public ActionBasedController rightHandController;
    public InputActionProperty activateAction; // Assuming this is for the welding trigger

    public bool waiting = false;

    private void OnEnable()
    {
        // Subscribe to input action events for right-hand controller
        activateAction.action.performed += _ => TryCreateNewWeld();
    }

    private void OnDisable()
    {
        // Unsubscribe from input action events for right-hand controller
        activateAction.action.performed -= _ => TryCreateNewWeld();
    }

    // Update is called once per frame
    void Update()
    {
        // Now only checking for waiting or contact state, input handled through event subscription
        if (waiting || !wH.contact)
        {
            return;
        }
    }

    IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(0.1f);
        waiting = false;
    }

    void TryCreateNewWeld()
    {
        //if (wH.contact)
        //{
            CreateNewWeld();
        //}
    }

    void CreateNewWeld()
    {
        var instance = Instantiate(weldInstance);
        instance.transform.parent = weldholder.transform;
        instance.transform.position = welderHead.transform.position + new Vector3(0, yoffset, 0);
        StartCoroutine(Wait());
    }
}
