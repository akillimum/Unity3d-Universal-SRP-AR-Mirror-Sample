using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class disables all AR related content so you can test scene on editor run
/// </summary>
public class ARSwitcher : MonoBehaviour {

    public bool IsEnabled = false;
    public GameObject NormalCamera;
    public GameObject CameraParent;
    public GameObject ARCameraManager;
    //public UnityARKitLightManager UnityARKitLightManager;
    //public ARKitSquareManager ARKitSquareManager;
    //public CamTransformer CamTransformer;

	void Awake () {
        if (IsEnabled)
        {
            NormalCamera.SetActive(true);
            NormalCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;

            CameraParent.SetActive(false);

            ARCameraManager.SetActive(false);

            //UnityARKitLightManager.enabled = false;
            //ARKitSquareManager.enabled = false;
            //CamTransformer.enabled = false;
        }
	}

    void Update(){
        if (IsEnabled)
        {
            //if (InputController.ActiveVehicle != null && !InputController.ActiveVehicle.activeSelf)
            //{
            //    InputController.ActiveVehicle.transform.position = new Vector3(0, 3f, 0);//a little high :)
            //    InputController.ActiveVehicle.SetActive(true);
            //}
        }
    }
}
