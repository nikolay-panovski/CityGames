using UnityEngine;

public class SimpleBillboard : MonoBehaviour
{
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void LateUpdate()
    {
        transform.rotation = mainCamera.transform.rotation;
    }
}
