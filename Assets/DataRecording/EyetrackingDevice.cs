using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.WebCam;
using ViveSR.anipal.Eye;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

public class EyetrackingDevice : MonoBehaviour
{
    private bool _isCalibrating;
    private bool _isCalibrated;
    private bool _isRecording;
    private float _sampleRate;
    private int _penetratedLayer;
    private Transform _hmdTransform;

    private string content;

    private int ii = 0;

    [SerializeField] private List<EyeTrackingDataFrame> _eyeTrackingDataFrames;
    /// //////////////////////////////////////////
    private Coroutine _recordingCoroutine;
    /// //////////////////////////////////////////
    /// 


    //Only for a VIVE Pro EYE! you have to addapt this if you want another form of eyetracker

    private void Start()
    {
        _eyeTrackingDataFrames = new List<EyeTrackingDataFrame>();
        _isRecording = false;
        _isCalibrated = false;
        _isCalibrating = false;
    }


    public void StartCalibration()
    {
        if (_isRecording || _isCalibrating) return;
        _isCalibrating = true;
        _isCalibrated = SRanipal_Eye_v2.LaunchEyeCalibration();
    }


    public void StartRecording()
    {
        if (_isRecording)
        {
            Debug.LogWarning("Recording is already in progress continue with current Recording");
            return;
        }

        _isRecording = true;
        //StartCoroutine(Recording());
        /////////////////////////////////////////////////////
        /*_recordingCoroutine = StartCoroutine(RecordingCoroutine());*/
        /////////////////////////////////////////////////////
    }

    private void FixedUpdate()
    {

        if (_isRecording)
        {

            EyeTrackingDataFrame frame = new EyeTrackingDataFrame();

            frame.timestamp = TimeManager.Instance.GetCurrentUnixTimeStamp();
            frame.timestampstring = TimeManager.Instance.GetCurrentUnixTimeStampString();
            frame.Loacltimestamp = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            frame.Localtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            VerboseData data;


            //HMD Data
            frame.hmdPosition = _hmdTransform.transform.position;
            frame.hmdRotation = _hmdTransform.transform.rotation.eulerAngles;


            SRanipal_Eye_v2.GetVerboseData(out data); //Depending on using Sranipal_eye_v2 or v1 //Here you get the device data

            //fill dataframe  with data from the verbose data


            var leftEyeData = data.left;
            var rightEyeData = data.right;
            var combinedData = data.combined;

            //validity

            // left eye data

            Vector3 coordinateAdaptedGazeDirectionLeft = new Vector3(leftEyeData.gaze_direction_normalized.x * -1, leftEyeData.gaze_direction_normalized.y, leftEyeData.gaze_direction_normalized.z);
            //local
            frame.eyePositionLeftLocal = leftEyeData.gaze_origin_mm;
            frame.eyeDirectionLeftLocal = coordinateAdaptedGazeDirectionLeft;
            //global
            frame.eyePositionLeftWorld = leftEyeData.gaze_origin_mm / 1000 + _hmdTransform.position;
            frame.eyeDirectionLeftWorld = _hmdTransform.rotation * coordinateAdaptedGazeDirectionLeft;

            // Openness and Pupil Diameter
            frame.eyeOpennessLeft = leftEyeData.eye_openness;
            frame.eyePupilDiameterLeft = leftEyeData.pupil_diameter_mm;

            //right eye data

            Vector3 coordinateAdaptedGazeDirectionRight = new Vector3(rightEyeData.gaze_direction_normalized.x * -1, rightEyeData.gaze_direction_normalized.y, rightEyeData.gaze_direction_normalized.z);
            frame.eyePositionRightLocal = rightEyeData.gaze_origin_mm;
            frame.eyeDirectionRightLocal = coordinateAdaptedGazeDirectionRight;
            //global
            frame.eyePositionRightWorld = rightEyeData.gaze_origin_mm / 1000 + _hmdTransform.position;
            frame.eyeDirectionRightWorld = _hmdTransform.rotation * coordinateAdaptedGazeDirectionRight;

            // Openness and Pupil Diameter
            frame.eyeOpennessRight = rightEyeData.eye_openness;
            frame.eyePupilDiameterRight = rightEyeData.pupil_diameter_mm;

            //combined eye - average the eye position and direction

            Vector3 coordinateAdaptedGazeDirectionCombined = new Vector3(combinedData.eye_data.gaze_direction_normalized.x * -1, combinedData.eye_data.gaze_direction_normalized.y, combinedData.eye_data.gaze_direction_normalized.z);
            frame.EyePositionCombinedLocal = combinedData.eye_data.gaze_origin_mm;
            frame.EyeDirectionCombinedLocal = coordinateAdaptedGazeDirectionCombined;

            frame.EyePositionCombinedWorld = combinedData.eye_data.gaze_origin_mm / 1000 + _hmdTransform.position;
            frame.EyeDirectionCombinedWorld = _hmdTransform.rotation * coordinateAdaptedGazeDirectionCombined;

            frame.pupilpositionLeft = leftEyeData.pupil_position_in_sensor_area;
            frame.pupilpositionRight = rightEyeData.pupil_position_in_sensor_area;


            HitObjectInfo hitObjectInfo = new HitObjectInfo();
            RaycastHit hit;
            if (Physics.Raycast(frame.EyePositionCombinedWorld, frame.EyeDirectionCombinedWorld, out hit))
            {
                hitObjectInfo.ObjectName = hit.collider.name;
                hitObjectInfo.ObjectTag = hit.collider.gameObject.tag;
                frame.singleHitInfo = hitObjectInfo;

            }
            else
            {
                hitObjectInfo.ObjectName = null;
                hitObjectInfo.ObjectTag = null;
            }

            

            _eyeTrackingDataFrames.Add(frame);
        }


    }

    public void StopRecording()
    {
        _isRecording = false;
        //////////////////////////////////
        if (_recordingCoroutine != null)
        {
            StopCoroutine(_recordingCoroutine);
        }
        ////////////////////////////////////////
    }

    public void SetSampleRate(float sampleRate)
    {
        _sampleRate = sampleRate;
    }

    public void SetHMDTransform(Transform HMDTransform)
    {
        _hmdTransform = HMDTransform;
    }

    public void SetPenetratedLayers(int number)
    {
        _penetratedLayer = number;
    }

    public List<EyeTrackingDataFrame> GetCurrentFrames()
    {
        return _eyeTrackingDataFrames;
    }

    public void ClearData()
    {
        _eyeTrackingDataFrames.Clear();
    }
}
