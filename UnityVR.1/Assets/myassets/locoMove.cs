//David Baron-Vega - GFF7068 - 3.29

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BasicLocomotion : MonoBehaviour
{
    public SteamVR_Action_Vector2 moveAction;
    public float speed = 3.0f;

    void Update()
    {
        Vector2 trackpadValue = moveAction.GetAxis(SteamVR_Input_Sources.LeftHand);
        Vector3 moveDirection = new Vector3(trackpadValue.x, 0, trackpadValue.y);
        
        // Convert moveDirection from local to world space if necessary
        moveDirection = transform.TransformDirection(moveDirection);
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
