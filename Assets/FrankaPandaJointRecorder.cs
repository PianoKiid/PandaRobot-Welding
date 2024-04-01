using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DataRecorder : MonoBehaviour
{
    public FrankaPanda_f pandaArm; // Reference to the FrankaPanda_f script attached to the robot arm
    public GameObject welderHead; // Reference to the welder head object
    public float yoffset = 0.5f; // Y offset for the position recording
    private List<string> records; // List to hold both joint angle and position records
    private float recordFrequency = 0.02f; // How often to record the data in seconds
    private float nextRecordTime = 0.0f;

    public ActionBasedController rightHandController;
    public InputActionProperty activateAction; // For the welding trigger

    private bool triggerPressed = false; // Tracks the trigger press state

    private void OnEnable()
    {
        activateAction.action.performed += OnTriggerPressed;
        activateAction.action.canceled += OnTriggerReleased;
    }

    private void OnDisable()
    {
        activateAction.action.performed -= OnTriggerPressed;
        activateAction.action.canceled -= OnTriggerReleased;
    }

    // Start is called before the first frame update
    void Start()
    {
        records = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if it's time to record the data
        if (Time.time >= nextRecordTime)
        {
            RecordData();
            nextRecordTime += recordFrequency;
        }
    }

    private void OnTriggerPressed(InputAction.CallbackContext context)
    {
        triggerPressed = true;
    }

    private void OnTriggerReleased(InputAction.CallbackContext context)
    {
        triggerPressed = false;
    }

    void RecordData()
    {
        if (pandaArm != null)
        {
            // Clone the current joint angles to prevent reference issues
            float[] currentJoints = (float[])pandaArm.q.Clone();
            string jointData = string.Join(", ", currentJoints);

            string positionData = "null"; // Default value when trigger is not pressed
            int triggerState = triggerPressed ? 1 : 0; // 1 if the trigger is pressed, 0 otherwise

            if (triggerPressed)
            {
                // Record position if the trigger is pressed
                Vector3 position = welderHead.transform.position + new Vector3(0, yoffset, 0);
                positionData = $"{position.x}, {position.y}, {position.z}";
            }

            // Combine joint, position data, and trigger state
            string record = $"{jointData} | {positionData} | {triggerState}";
            records.Add(record);
        }
    }

    void OnDestroy()
    {
        // Get the current date in MMddHHmm format
        string currentDate = System.DateTime.Now.ToString("MMddHHmm");
        string filePath = $"C:/Users/sungboo/Documents/GitHub/PandaInterface/Assets/Data/log_{currentDate}.txt";

        // Write the records to the file
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (string record in records)
            {
                sw.WriteLine(record);
            }
        }

        Debug.Log($"Records saved to: {filePath}");
    }
}
