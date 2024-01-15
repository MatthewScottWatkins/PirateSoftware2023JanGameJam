using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private GameObject lookAt;

    void Start()
    {
        cam.Follow = null;
        cam.LookAt = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            cam.Follow = null;
            cam.LookAt = null;
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            cam.Follow = lookAt.transform;
            cam.LookAt = lookAt.transform;
        }


        //will return to. TODO: stop camera snapping

        //if (Input.GetMouseButtonDown(1))
        //{
        //    oldMousePosition = Input.mousePosition;
        //    return;
        //}


        //if (Input.GetMouseButton(1))
        //{

        //    Vector3 currentMousePosition = Input.mousePosition;

        //    if (currentMousePosition.x < oldMousePosition.x)
        //    {
        //        float x = cam.transform.eulerAngles.x;
        //        float y = cam.transform.eulerAngles.y;
        //        cam.transform.eulerAngles = new Vector3(x, y + rotationSpeed);
        //    }

        //    if (currentMousePosition.x > oldMousePosition.x)
        //    {
        //        float x = cam.transform.eulerAngles.x;
        //        float y = cam.transform.eulerAngles.y;
        //        cam.transform.eulerAngles = new Vector3(x, y - rotationSpeed);
        //    }
        //    Debug.Log(currentMousePosition);
        //}


    }
}
