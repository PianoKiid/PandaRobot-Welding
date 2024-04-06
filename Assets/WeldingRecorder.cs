using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class WeldingRecorder : MonoBehaviour
{
    [Header("Welding Properties")]
    public Transform weldingTip; // Use a custom Transform as the tip of the welding pen
    [Range(0.01f, 0.1f)]
    public float weldWidth = 0.01f;
    public Material weldingMaterial; // Material for the welding effect

    [Header("Joystick")]
    public ActionBasedController rightHandController;
    public InputActionProperty activateAction;

    private LineRenderer currentWeldingLine;
    private int index;

    private void OnEnable()
    {
        activateAction.action.performed += OnActivatePerformed;
        activateAction.action.canceled += OnActivateCanceled;
    }

    private void OnDisable()
    {
        activateAction.action.performed -= OnActivatePerformed;
        activateAction.action.canceled -= OnActivateCanceled;
    }

    private void OnActivatePerformed(InputAction.CallbackContext context)
    {
        if (currentWeldingLine == null) // Start a new line if there isn't one active
        {
            StartCoroutine(StartWeldingAfterDelay());
        }
    }

    private IEnumerator StartWeldingAfterDelay()
    {
        yield return null; // Wait for the next frame so the weldingTip's position is updated
        StartWelding();
    }

    private void StartWelding()
    {
        GameObject newWeldingLine = new GameObject("DynamicWeldingLine");
        currentWeldingLine = newWeldingLine.AddComponent<LineRenderer>();
        currentWeldingLine.material = weldingMaterial;
        currentWeldingLine.startWidth = currentWeldingLine.endWidth = weldWidth;
        currentWeldingLine.positionCount = 1;
        currentWeldingLine.SetPosition(0, weldingTip.position); // Set initial position correctly
        index = 0;
    }

    private void Update()
    {
        if (currentWeldingLine != null)
        {
            AddWeldingPoint();
        }
    }

    private void AddWeldingPoint()
    {
        if (index == 0 || Vector3.Distance(currentWeldingLine.GetPosition(index), weldingTip.position) > 0.01f)
        {
            index++;
            currentWeldingLine.positionCount = index + 1;
            currentWeldingLine.SetPosition(index, weldingTip.position);
        }
    }

    private void OnActivateCanceled(InputAction.CallbackContext context)
    {
        EndWelding();
    }

    private void EndWelding()
    {
        currentWeldingLine = null; // Reset the line when welding ends
    }
}
