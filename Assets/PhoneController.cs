using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public GameObject phoneIcon;
    public PhoneScreen defaultScreen;
    public PhoneScreen currentScreen;
    public PhoneScreen previousScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScreen(PhoneScreen newScreen)
    {
        bool isPhoneActive = currentScreen.gameObject.activeSelf;
        previousScreen = currentScreen;
        previousScreen.gameObject.SetActive(false);
        currentScreen = newScreen;
        currentScreen.gameObject.SetActive(isPhoneActive);  // make the newly referenced screen immediately active only if the old one was also active
    }
}
