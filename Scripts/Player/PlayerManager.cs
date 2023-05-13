using JG;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerManager : CharacterManager
{

    InputHandler inputHandler;
    Animator anim;
    CameraHandler cameraHandler;
    PlayerLocomotion playerLocomotion;
    

    [Header("Player Flags")]
    public bool canDoCombo;
    public bool isInteracting;
    public bool isSprinting;
    public bool isUsingRightHand;
    public bool isUsingLeftHand;    
   

    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
        cameraHandler = CameraHandler.singleton;
        playerLocomotion = GetComponent<PlayerLocomotion>();
        
    }

    void Update()
    {

        float delta = Time.deltaTime;

        
        isInteracting = anim.GetBool("isInteracting");
        
        
        canDoCombo = anim.GetBool("canDoCombo");
        inputHandler.TickInput(delta);
        playerLocomotion.HandleRollingAndSprinting(delta);
        playerLocomotion.HandleMovement(delta);
        isUsingLeftHand = anim.GetBool("isUsingLeftHand");
        isUsingRightHand = anim.GetBool("isUsingRightHand");



    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;
        

    }

    private void LateUpdate()
    {

        float delta = Time.deltaTime;

        inputHandler.sprintFlag = false;
        inputHandler.rollFlag = false;
        inputHandler.rb_Input = false;
        inputHandler.rt_Input = false;
        isSprinting = inputHandler.leftShift;

             

        if (cameraHandler != null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
        }
    }

}
