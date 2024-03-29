﻿//David Baron-Vega 03.28.24
//GF7068
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR; //used for changing bindings\
using Valve.VR.InteractionSystem; //Used to reference to VR game-objects.

public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 1;
    private CharacterController characterController;

    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(input.axis.magnitude > 0.1f)
    {
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));  
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction,Vector3.up) - new Vector3(0,9.81f,0)*Time.deltaTime);
    }
    }
}