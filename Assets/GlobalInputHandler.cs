using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInputHandler : MonoBehaviour
{
    public KeyCode popupCloseKey;

    void Update()
    {
        if (Input.GetKeyDown(popupCloseKey))
        {
            FindObjectOfType<Canvas>().gameObject.SetActive(false); // might need to expand after specific popups
        }

    }
}
