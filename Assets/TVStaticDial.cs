using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVStaticDial : MonoBehaviour
{
    public TVStaticSprite manipulatedStatic;
    private SpriteRenderer staticSprite;
    private Collider thisCollider;
    public Camera mainCamera;
    public bool isRotatingDial;
    public float dialRotation;

    void Start()
    {
        mainCamera = Camera.main;
        staticSprite = manipulatedStatic.GetComponent<SpriteRenderer>();
        thisCollider = GetComponent<Collider>();
        dialRotation = manipulatedStatic.targetRotation + 180f;     // ensure the screen will start with full static
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray fromMouse = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            if (Physics.Raycast(fromMouse, out RaycastHit hit))
            {
                if (hit.collider == thisCollider) isRotatingDial = true;
            }
        }

        if (isRotatingDial)
        {
            float mouseMovement = Input.GetAxis("Mouse X");
            transform.rotation *= Quaternion.AngleAxis(mouseMovement, Vector3.up);

            dialRotation += mouseMovement;
            if (dialRotation > 360f) dialRotation -= 360f;  // TODO: fix snap around 0 degrees due to "shortest angle difference"
            if (dialRotation < 0f) dialRotation += 360f;

            staticSprite.color = new Color(staticSprite.color.r, staticSprite.color.g, staticSprite.color.b,
                                            Util.Remap(Mathf.Abs(manipulatedStatic.targetRotation - dialRotation), 0, 180, 0, 1));
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRotatingDial = false;
        }
    }

    public void ResetStatic()
    {
        staticSprite.color = Color.white;
        manipulatedStatic.targetRotation += 180f;
        if (manipulatedStatic.targetRotation > 360f) manipulatedStatic.targetRotation -= 360f;
        if (manipulatedStatic.targetRotation < 0f) manipulatedStatic.targetRotation += 360f;
    }
}
