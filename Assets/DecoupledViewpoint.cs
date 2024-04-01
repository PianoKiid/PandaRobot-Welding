using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DecoupledViewpoint : MonoBehaviour
{
    public ActionBasedController leftHandController;
    public InputActionReference leftPrimary2DAxisActionReference;
    public InputActionReference leftTriggerActionReference;

    public float movementSpeed = 1.0f;

    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = transform; // Initialize the cameraTransform with this object's transform
    }

    void Update()
    {
        // Get the value from the left controller's 2D axis action reference
        Vector2 primary2DAxis = leftPrimary2DAxisActionReference.action.ReadValue<Vector2>();

        // Get the trigger value to determine if Y movement should be enabled
        float triggerValue = leftTriggerActionReference.action.ReadValue<float>();

        // Initialize movement vector
        Vector3 movement = Vector3.zero;

        // Check the trigger value to determine the movement direction
        if (triggerValue > 0.1) // Using a threshold to avoid unintentional movement due to trigger sensitivity
        {
            // If the trigger is pressed, use the Y-axis of the joystick for Y movement
            movement = new Vector3(0, primary2DAxis.y * movementSpeed * Time.deltaTime, 0);
        }
        else
        {
            // If the trigger is not pressed, use the joystick's X and Y for X and Z movement
            movement = new Vector3(primary2DAxis.x * movementSpeed * Time.deltaTime, 0, primary2DAxis.y * movementSpeed * Time.deltaTime);
        }

        // Apply the movement to the camera's position
        cameraTransform.position += cameraTransform.TransformDirection(movement);
    }
}
