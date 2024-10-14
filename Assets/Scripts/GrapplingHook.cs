using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    private Vector3 grapplePoint;
    RaycastHit hit;
    private SpringJoint joint;

    public KeyCode grappleKeyCode = KeyCode.F;
    public LineRenderer lr;
    public LayerMask whatIsGrappleable;
    public Transform tip, cam, player;
    public float maxDistance = 100f;
    public Vector3 grapplingHookRotation;

    [Header("Joint")]
    public float jointMaxDistanceMultiplier = 0.8f;
    public float jointMinDistanceMultiplier = 0.25f;
    public float jointSpring = 4.5f;
    public float jointDamper = 7f;
    public float jointMassScale = 4.5f;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(grappleKeyCode))
        {
            StartGrapple();
        } 
        else if(Input.GetKeyUp(grappleKeyCode))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, whatIsGrappleable))
        {
            transform.localRotation = Quaternion.Euler(180, 180, 0);
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);
            joint.maxDistance = distanceFromPoint * jointMaxDistanceMultiplier;
            joint.minDistance = distanceFromPoint * jointMinDistanceMultiplier;
            joint.spring = jointSpring;
            joint.damper = jointDamper;
            joint.massScale = jointMassScale;

            lr.positionCount = 2;
        }
    }

    void DrawRope()
    {
        if (!joint) return;
        lr.SetPosition(0, tip.position);
        lr.SetPosition(1, grapplePoint);
    }

    void StopGrapple()
    {
        transform.localEulerAngles = grapplingHookRotation;
        lr.positionCount = 0;
        Destroy(joint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
