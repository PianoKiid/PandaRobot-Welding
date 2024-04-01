using UnityEngine;

public class CoupledViewpoint : MonoBehaviour
{
    public Transform target; // The target object the XR Origin should follow
    public Vector3 offset; // The offset from the target object
    public Transform xrOriginTransform; // Reference to the XR Origin's transform

    void Start()
    {
        // If the XR Origin transform is not set, try to use this object's transform
        if (xrOriginTransform == null)
        {
            xrOriginTransform = GetComponent<Transform>();
        }
    }

    void LateUpdate()
    {
        // Update the XR Origin's position to follow the target object with the given offset
        // This assumes you want the offset to be relative to the target object's orientation
        xrOriginTransform.position = target.position + target.TransformDirection(offset);
    }
}
