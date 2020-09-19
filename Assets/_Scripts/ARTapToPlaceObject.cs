using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject PlacementIndicator;
    public GameObject CanvasSearching;
    public GameObject CanvasFound;
    //public GameObject CanvasGamePlay;
    //public GameObject CanvasCarSelection;

    //public InputController InputController;
    public GameObject Car;
    public FloorController FloorController;

    public ARRaycastManager _arRaycastManager;
    public Camera _camera;
    //public Slider ScaleSlider;
    private Pose _placementPose;
    private bool _placementPoseIsValid = false;
    private bool _isTrackingStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        //_arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTrackingStarted) //if game is started do not check anymore
            return;

        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacementIndicator()
    {
        if (_placementPoseIsValid)
        {
            CanvasSearching.SetActive(false);
            //CanvasGamePlay.SetActive(false);
            //CanvasCarSelection.SetActive(false);
            CanvasFound.SetActive(true);

            PlacementIndicator.SetActive(true);
            PlacementIndicator.transform.SetPositionAndRotation(_placementPose.position, _placementPose.rotation);

            //you can use the touch position as the creation position, but i will use the center pose :)
            if (TryGetTouchPosition(out Vector2 touchPosition))
            {
                _isTrackingStarted = true;

                //disable main searching canvases and indicator, and show game play canvas
                CanvasSearching.SetActive(false);
                CanvasFound.SetActive(false);
                //CanvasGamePlay.SetActive(true);

                PlacementIndicator.SetActive(false);

                //show plane and car
                FloorController.SetPositionAndShow(_placementPose.position); //show floor
                
                Car.transform.position = new Vector3(_placementPose.position.x,
                    _placementPose.position.y + 0.015f, //because our car pivot is a little bit above :)
                    _placementPose.position.z);
                Car.SetActive(true);

                //_arSessionOrigin.MakeContentAppearAt(InputController.GetActiveVehicle().transform,
                //  InputController.GetActiveVehicle().transform.position);
                //ScaleSlider.value = 0.1f; //to make car a little smaller

            }
        }
        else
        {
            CanvasSearching.SetActive(true);
            CanvasFound.SetActive(false);
            //CanvasGamePlay.SetActive(false);

            PlacementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = _camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
     
        var hits = new List<ARRaycastHit>();
        _arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        _placementPoseIsValid = hits.Count > 0;
        if(_placementPoseIsValid)
        {
            _placementPose = hits[0].pose;

            //to turn indicator always to looking direction
            var cameraForward = _camera.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            _placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            touchPosition = new Vector2(mousePosition.x, mousePosition.y);
            return true;
        }
#else
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
#endif

        touchPosition = default;
        return false;
    }
}
