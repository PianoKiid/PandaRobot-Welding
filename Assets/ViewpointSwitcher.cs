using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public Camera CoupledViewpoint;
    public Camera DecoupledViewpoint;

    // Call this function to disable the coupled camera,
    // and enable the decoupled camera.
    public void ShowOverheadView()
    {
        CoupledViewpoint.enabled = false;
        DecoupledViewpoint.enabled = true;
    }

    // Call this function to enable the coupled camera,
    // and disable the decoupled camera.
    public void ShowFirstPersonView()
    {
        CoupledViewpoint.enabled = true;
        DecoupledViewpoint.enabled = false;
    }
}
