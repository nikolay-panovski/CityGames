using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorsePaperToggle : MonoBehaviour
{
    public Camera mainCamera;
    private Collider thisCollider;

    public GameObject paperBig;

    void Start()
    {
        mainCamera = Camera.main;
        thisCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray fromMouse = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            if (Physics.Raycast(fromMouse, out RaycastHit hit))
            {
                if (hit.collider == thisCollider)
                {
                    paperBig.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
