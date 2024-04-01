using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class NewViewpointSwitcher : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private bool isFollowing = false;
    private int i = 0;

    public ActionBasedController leftHandController;
    /*    public InputActionProperty activateAction;

        void OnEnable()
        {
            // Register the callback for the activate action
            activateAction.action.performed += ToggleFollow;
        }

        void OnDisable()
        {
            // Unregister the callback when the script is disabled
            activateAction.action.performed -= ToggleFollow;
        }*/

    /*    private void ToggleFollow(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            // Toggle the following state when the action is performed
            isFollowing = !isFollowing;
        }*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) == true)
        {
            if (isFollowing == false)
            {
                Debug.Log("I++");
                i += 1;
                if (i == 10)
                {
                    isFollowing = true;
                    i = 0;
                }
                Debug.Log(i);

            }

            if (isFollowing)
            {
/*                Debug.Log("Not Follow");*/
/*                isFollowing = false;*/
            }
        }
    }


    void FixedUpdate()
    {
        if (isFollowing)
        {
            Debug.Log("Following...");
            // Update the position only if isFollowing is true
            /*            Vector3 desiredPosition = target.position + offset;
                        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                        transform.position = smoothedPosition;

                        // Assuming you still want the camera to look at the target when following
                        transform.LookAt(target);*/

            transform.position = target.position;

        }
        // When isFollowing is false, do nothing, and the camera will stay in its last position and orientation
    }
}
