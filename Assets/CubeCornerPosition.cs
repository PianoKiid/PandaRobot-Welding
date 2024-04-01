using UnityEngine;

public class CubeCornerPosition : MonoBehaviour
{
    public GameObject cube; // Assign this in the inspector

    void Start()
    {
        Vector3 topCorner = GetTopFrontRightCorner(cube);
        Debug.Log("Top Front Right Corner: " + topCorner);
    }

    Vector3 GetTopFrontRightCorner(GameObject cube)
    {
        // Get the cube's transform
        Transform cubeTransform = cube.transform;

        // Calculate the half size of the cube
        Vector3 halfSize = cubeTransform.localScale / 2.0f;

        // Calculate and return the position of the top front right corner
        return cubeTransform.position + cubeTransform.right * halfSize.x + cubeTransform.up * halfSize.y + cubeTransform.forward * halfSize.z;
    }
}
