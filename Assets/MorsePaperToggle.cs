using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorsePaperToggle : MonoBehaviour
{
    public Camera mainCamera;

    public GameObject paperBig;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray fromMouse = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            if (Physics.Raycast(fromMouse))
            {
                paperBig.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
