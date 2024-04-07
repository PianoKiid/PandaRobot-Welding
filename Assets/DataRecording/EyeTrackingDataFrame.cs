using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EyeTrackingDataFrame
{
    //Unix Time Stamp

    public double timestamp;
    public string timestampstring;
    public double Loacltimestamp;
    public string Localtime;


    public string dr_onestampstring;

    public string dan_gerstampstring;

    //HMD Data
    public Vector3 hmdPosition;      //be careful for serialization, Vector3 might not be serializable with your approach
    public Vector3 hmdRotation;
    //transport.forward

    //Gaze Validity - Data Cleanse - Flags interpreted as bit Mask

    //LeftEye
    public Vector3 eyePositionLeftLocal;
    public Vector3 eyeDirectionLeftLocal;
    public Vector3 eyePositionLeftWorld;
    public Vector3 eyeDirectionLeftWorld;
    public float eyeOpennessLeft;
    public float eyePupilDiameterLeft;

    //rightEye
    public Vector3 eyePositionRightLocal;
    public Vector3 eyeDirectionRightLocal;
    public Vector3 eyePositionRightWorld;
    public Vector3 eyeDirectionRightWorld;
    public float eyeOpennessRight;
    public float eyePupilDiameterRight;
    public Vector2 pupilpositionLeft;
    public Vector2 pupilpositionRight;

    //combined Gaze- " combined eye" - cyclope eye
    public Vector3 EyePositionCombinedLocal;
    public Vector3 EyeDirectionCombinedLocal;
    public Vector3 EyePositionCombinedWorld;
    public Vector3 EyeDirectionCombinedWorld;

    public HitObjectInfo singleHitInfo;
    //Raycast Data normaly done just with the Gaze instead of single eye

}



[Serializable]
public class HitObjectInfo
{

    public string ObjectTag;

    public string ObjectName;
}

[Serializable]
public class Validty
{
    public bool val;
}



