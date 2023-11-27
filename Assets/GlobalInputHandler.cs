using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInputHandler : MonoBehaviour
{
    public KeyCode popupCloseKey;
    public KeyCode phoneToggleKey;

    void Update()
    {
        if (Input.GetKeyDown(popupCloseKey))
        {
            FindObjectOfType<Canvas>().gameObject.SetActive(false); // might need to expand after specific popups
        }

        if (Input.GetKeyDown(phoneToggleKey))
        {
            // TODO: toggle between phone big screen and phone small icon on UI
        }
    }
}
