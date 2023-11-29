using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QRClickable : MonoBehaviour
{
    public UnityEvent OnQRCollect;

    private Camera mainCamera;
    private Collider thisCollider;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        thisCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray fromMouse = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            if (Physics.Raycast(fromMouse, out RaycastHit hit))
            {
                if (hit.collider == thisCollider) OnQRCollect.Invoke();
                this.gameObject.SetActive(false);
            }
        }
    }
}
