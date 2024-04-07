using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyetrackingManager : MonoBehaviour
{
    public static EyetrackingManager Instance { get; private set; }
    private EyetrackingDevice _eyetrackingDevice;
    /*public int SetSampleRate;*/
    public int SetPenetratedLayers = 1;
    [SerializeField] private Transform _hmdTransform;

    private float _sampleRate;



    //singleton Pattern (also notice the call in line 7) which allows to find the Instance everywhere in the scene by Using EyetrackingManager.Instance
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _eyetrackingDevice = GetComponent<EyetrackingDevice>(); //Only if you add the Eyetracking device on the same Gameobject!
        _sampleRate = 0.2f;

        _eyetrackingDevice.SetSampleRate(_sampleRate);
        _eyetrackingDevice.SetHMDTransform(_hmdTransform);
        _eyetrackingDevice.SetPenetratedLayers(SetPenetratedLayers);
    }

    //We use this Update method for Debug purposes, for a real experiment, call those functions in a Experiment Manager
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartEyetrackingRecording();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            StopEyetrackingRecording();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCalibration();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            SaveDataToDisk();
        }

    }

    public void StartEyetrackingRecording()
    {
        Debug.Log("Start Recording...");
        _eyetrackingDevice.StartRecording();
    }

    public void StopEyetrackingRecording()
    {
        _eyetrackingDevice.StopRecording();
    }

    public void ClearDataFrames()
    {
        _eyetrackingDevice.ClearData();
    }

    public void StartCalibration()
    {
        _eyetrackingDevice.StartCalibration();
    }

    public void StartValidation()
    {

    }


    public void SaveDataToDisk()
    {
        _eyetrackingDevice.StopRecording();
        ////////////////////////////////////////////////   MJ Code   ////////////////////////////////////////////////
        DataSavingManager.Instance.SaveList(_eyetrackingDevice.GetCurrentFrames(), "Eye Tracking Data " + TimeManager.Instance.GetCurrentUnixTimeStamp());
        //List<string> loadedData = DataSavingManager.Instance.LoadFileList<string>("Test session " + TimeManager.Instance.GetCurrentUnixTimeStamp());
        ////////////////////////////////////////////////   MJ Code   ////////////////////////////////////////////////
    }

}
