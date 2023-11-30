using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public GameObject phoneIcon;
    public PhoneScreen defaultScreen;
    public PhoneScreen currentScreen;
    public PhoneScreen previousScreen;
    public PhoneScreen finalScreen;

    public PhoneScreen wrongAnswerScreen;

    public void UpdateScreen(PhoneScreen newScreen)
    {
        bool isPhoneActive = currentScreen.gameObject.activeSelf;
        previousScreen = currentScreen;
        previousScreen.gameObject.SetActive(false);
        currentScreen = newScreen;
        currentScreen.gameObject.SetActive(isPhoneActive);  // make the newly referenced screen immediately active only if the old one was also active
    }
}
