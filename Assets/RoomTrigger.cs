using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public PhoneScreen phoneScreen;

    public void UpdatePhoneScreen(PhoneScreen newScreen)
    {
        phoneScreen = newScreen;
    }
}
