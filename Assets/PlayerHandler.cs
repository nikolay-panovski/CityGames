using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public PhoneController phone;

    // Start is called before the first frame update
    void Start()
    {
        phone = FindObjectOfType<PhoneController>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<RoomTrigger>(out RoomTrigger room))
        {
            phone.UpdateScreen(room.phoneScreen);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<RoomTrigger>(out _))
        {
            phone.UpdateScreen(phone.defaultScreen);
        }
    }
}
