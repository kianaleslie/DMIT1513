using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.SceneView;

public class CameraSwitcher : MonoBehaviour
{
    public Camera topDownCam;
    public Camera thirdPersonCam;
    public Camera firstPersonCam;
    public Camera sideCam;
    bool isFirstPersonView = false;

    //if an interaction is in progress
    bool isInteracting = false; 

    public Transform followingCameraPosition; 
    public Transform interactionCameraPosition; 

    Keyboard kb;

    void Start()
    {
        kb = Keyboard.current;
        topDownCam.enabled = true;
        thirdPersonCam.enabled = true;
        firstPersonCam.enabled = false;
        sideCam.enabled = false;
    }

    void Update()
    {
        if (isInteracting)
        {
            //handle camera positioning for the interaction
            transform.position = interactionCameraPosition.position;
            transform.rotation = interactionCameraPosition.rotation;
            sideCam.enabled = true;
            sideCam.depth = 3;
        }
        else
        {
            //camera switching
            if (kb.pKey.wasPressedThisFrame && !isInteracting)
            {
                isFirstPersonView = !isFirstPersonView;
                thirdPersonCam.enabled = isFirstPersonView;
                firstPersonCam.enabled = !isFirstPersonView;

                //top-down cam is always enabled when not interacting
                topDownCam.enabled = true;
            }
            else if (!isInteracting)
            {
                //camera positioning for following 
                transform.position = followingCameraPosition.position;
                transform.rotation = followingCameraPosition.rotation;
            }
            sideCam.enabled = false;
            sideCam.depth = 0;
        }
    }
    public void StartInteraction()
    {
        isInteracting = true;
    }
    public void EndInteraction()
    {
        isInteracting = false;
    }
}

//simple version without side cam stuff
//{
//    public Camera topDownCam;
//    public Camera thirdPersonCam;
//    public Camera firstPersonCam;
//    bool isFirstPersonView = false;

//    Keyboard kb;

//    void Start()
//    {
//        kb = Keyboard.current;
//        topDownCam.enabled = true;
//        thirdPersonCam.enabled = true;
//        firstPersonCam.enabled = false;
//    }
//    void Update()
//    {
//        if (kb.pKey.wasPressedThisFrame && topDownCam.enabled == true)
//        {
//            isFirstPersonView = !isFirstPersonView;

//            thirdPersonCam.enabled = isFirstPersonView;
//            firstPersonCam.enabled = !isFirstPersonView;
//        }
//    }
//}