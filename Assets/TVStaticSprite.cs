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
        targetRotation = coupledDial.dialRotation + 135;
        if (targetRotation > 360) targetRotation -= 360;
        if (targetRotation < 0) targetRotation += 360;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
