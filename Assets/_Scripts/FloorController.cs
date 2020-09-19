using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject PlaneFloor;

    private void Start()
    {
        Deactivate();
    }

    public void SetPositionAndShow(Vector3 position)
    {
        PlaneFloor.transform.position = position;
        PlaneFloor.SetActive(true);
    }

    public void Deactivate()
    {
        PlaneFloor.SetActive(false);
    }
}
