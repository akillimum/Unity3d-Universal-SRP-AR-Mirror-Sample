

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR.iOS;

//public class CamTransformer : MonoBehaviour
//{

//    public Camera NormalCamera;
//    public Camera ArCamera;
//    //public GameObject Car;
//    private float _cameraScale;
//    public static Vector3 ScaledObjectOrigin;
//    //private bool _sync = false;

//    private void Start()
//    {
//        _cameraScale = PlayerPrefsHelper.CameraScale;
//    }

//    private void Update()
//    {
//        Matrix4x4 matrix = UnityARSessionNativeInterface.GetARSessionNativeInterface().GetCameraPose();
//        float invScale = 1.0f / _cameraScale;
//        Vector3 cameraPos = UnityARMatrixOps.GetPosition(matrix);
//        Vector3 vecAnchorToCamera = cameraPos - ScaledObjectOrigin;
//        NormalCamera.transform.localPosition = ScaledObjectOrigin + (vecAnchorToCamera * invScale);
//        NormalCamera.transform.localRotation = UnityARMatrixOps.GetRotation(matrix);


//        //this needs to be adjusted for near/far
//        NormalCamera.projectionMatrix = UnityARSessionNativeInterface.GetARSessionNativeInterface().GetCameraProjection();

//    }

//    void LateUpdate()
//    {
//        CalculateShadowDistance();
//    }

//    public void MakeSmaller()
//    {
//        _cameraScale -= 0.02f;
//        PlayerPrefsHelper.CameraScale = _cameraScale;
//        LogMe();
//    }

//    public void MakeBigger()
//    {
//        _cameraScale += 0.02f;
//        PlayerPrefsHelper.CameraScale = _cameraScale;
//        LogMe();
//    }

//    private void CalculateShadowDistance()
//    {
//        float dist = Vector3.Distance(NormalCamera.transform.position,
//                                      InputController.ActiveVehicle.transform.position);
//        //Debug.Log("distance camera-car: " + dist);
//        QualitySettings.shadowDistance = dist*2;
//        //Debug.Log("camera to car distance: " + dist);
//    }

//    void LogMe()
//    {
//        Debug.Log("_cameraScale "+_cameraScale+Environment.NewLine+
//                  "NormalCamera.transform.position " + NormalCamera.transform.position + Environment.NewLine +
//                  "ArCamera.transform.position "+ArCamera.transform.position);
//    }
//}
