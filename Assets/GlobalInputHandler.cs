using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInputHandler : MonoBehaviour
{
    private Canvas mainCanvas;
    private PhoneController phone;

    public GameObject initPopup;

    public KeyCode popupCloseKey;
    public KeyCode phoneToggleKey;

    private void Start()
    {
        mainCanvas = FindObjectOfType<Canvas>(includeInactive: true);
        phone = FindObjectOfType<PhoneController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(popupCloseKey))
        {
            initPopup.SetActive(false);
        }

        if (Input.GetKeyDown(phoneToggleKey))
        {
            TogglePhoneDisplay();
        }
    }

    public void TogglePhoneDisplay()
    {
        phone.currentScreen.gameObject.SetActive(phone.currentScreen.gameObject.activeSelf ^ true);
        phone.phoneIcon.SetActive(!phone.currentScreen.gameObject.activeSelf);
    }
}
