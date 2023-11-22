using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVStaticDial : MonoBehaviour
{
    public Camera mainCamera;
    public bool isRotatingDial;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray fromMouse = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            if (Physics.Raycast(fromMouse))
            {
                isRotatingDial = true;
            }
        }

        if (isRotatingDial)
        {
            transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X"), Vector3.up);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotatingDial = false;
        }
    }
}
