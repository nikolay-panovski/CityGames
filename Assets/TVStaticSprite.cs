using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVStaticSprite : MonoBehaviour
{
    public TVStaticDial coupledDial;
    public float targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        targetRotation = TVStaticDial.dialRotation + 135f;
        if (targetRotation > 360f) targetRotation -= 360f;
        if (targetRotation < 0f) targetRotation += 360f;
    }
}
