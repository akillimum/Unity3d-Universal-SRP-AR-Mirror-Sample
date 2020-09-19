using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TestAsNormalScene : MonoBehaviour
{
    public AROcclusionManager OcclusionManager;
    public ARTapToPlaceObject ARTapToPlaceObject;
    public GameObject Car;
    public FloorController FloorController;
    public GameObject ARCamera;
    public GameObject TestCamera;
    public GameObject Floor;

    // Start is called before the first frame update
    void Start()
    {
        OcclusionManager.enabled = false;
        ARCamera.SetActive(false);
        TestCamera.SetActive(true);
        Floor.SetActive(true);
        ARTapToPlaceObject.enabled = false;
        FloorController.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        TryToCatchTap();
    }

    private void TryToCatchTap()
    {
        //you can use the touch position as the creation position, but i will use the center pose :)
        if (TryGetTouchPosition(out Vector2 touchPosition))
        {
            Debug.Log("clicked on plane: " + touchPosition);

            ////show plane and car
            //FloorController.SetPositionAndShow(_placementPose.position); //show floor

            //because our car's pivot is a little above the zero I set it here manually :)
            Car.transform.position = new Vector3(0, 0.015f, 0);
            Car.SetActive(true); //show vehicle

            ////_arSessionOrigin.MakeContentAppearAt(InputController.GetActiveVehicle().transform,
            ////  InputController.GetActiveVehicle().transform.position);
            //ScaleSlider.value = 0.1f; //to make car a little smaller

            this.enabled = false;
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
