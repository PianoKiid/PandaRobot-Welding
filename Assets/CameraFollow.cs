using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform cameraTransform; // The transform of the camera, which can be independently rotated

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        // Update the position
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // The rotation is now independent and should be handled separately, possibly in another script or method
        // For example, you might have a separate script that adjusts cameraTransform.rotation based on input
    }
}
