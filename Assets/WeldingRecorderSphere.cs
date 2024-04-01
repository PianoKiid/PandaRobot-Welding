using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class WeldingRecorderSphere : MonoBehaviour
{
    [Header("Welding Properties")]
    public Transform weldingTip; // Use a custom Transform as the tip of the welding pen
    [Range(0.01f, 1f)] // Adjusted range for size of the spheres
    public float weldSize = 0.1f; // Size of each welding sphere
    public Material weldingMaterial; // Material for the welding effect
    public GameObject weldingSpherePrefab; // Assign a prefab of a sphere in the inspector

    [Header("XR Controllers")]
    public ActionBasedController rightHandController;
    public InputActionProperty activateAction;

    private bool isWelding = false;

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
        isWelding = true;
    }

    private void Update()
    {
        if (isWelding)
        {
            AddWeldingPoint();
        }
    }

    private void AddWeldingPoint()
    {
        // Instantiate a new welding sphere at the tip's position
        GameObject sphere = Instantiate(weldingSpherePrefab, weldingTip.position, Quaternion.identity);
        sphere.transform.localScale = Vector3.one * weldSize; // Set the size of the sphere
        sphere.GetComponent<Renderer>().material = weldingMaterial; // Set the material of the sphere
    }

    private void OnActivateCanceled(InputAction.CallbackContext context)
    {
        isWelding = false; // Stop welding when the action is canceled
    }
}
