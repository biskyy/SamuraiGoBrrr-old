using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGrapplingHook : MonoBehaviour
{
    public GrapplingHook grapplingHook;
    public float rotationSpeed = 5f;

    private Quaternion desiredRotation;

    // Update is called once per frame
    void Update()
    {
        if (!grapplingHook.IsGrappling())
        {
            desiredRotation = transform.parent.rotation;
        }
        else
        {
            desiredRotation = Quaternion.LookRotation(grapplingHook.GetGrapplePoint() - transform.position);
        }

       transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }

    // -137.164
}
