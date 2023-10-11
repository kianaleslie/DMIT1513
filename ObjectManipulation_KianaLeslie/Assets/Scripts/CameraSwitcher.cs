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
    bool isFirstPersonView = false;
    bool isInteracting = false; // Flag to determine if an interaction is in progress.

    public Transform followingCameraPosition; // Add this for the camera's follow position.
    public Transform interactionCameraPosition; // Add this for the camera's interaction position.

    Keyboard kb;

    void Start()
    {
        kb = Keyboard.current;
        topDownCam.enabled = true;
        thirdPersonCam.enabled = true;
        firstPersonCam.enabled = false;
    }

    void Update()
    {
        if (isInteracting)
        {
            // Handle camera positioning for the interaction.
            transform.position = interactionCameraPosition.position;
            transform.rotation = interactionCameraPosition.rotation;
        }
        else
        {
            // Handle camera switching logic.
            if (kb.pKey.wasPressedThisFrame && !isInteracting)
            {
                isFirstPersonView = !isFirstPersonView;
                thirdPersonCam.enabled = isFirstPersonView;
                firstPersonCam.enabled = !isFirstPersonView;

                // Ensure the top-down cam is always enabled when not interacting.
                topDownCam.enabled = true;
            }
            else if (!isInteracting)
            {
                // Handle camera positioning for following mode.
                transform.position = followingCameraPosition.position;
                transform.rotation = followingCameraPosition.rotation;
            }
        }
    }

    // Call this method to start an interaction.
    public void StartInteraction()
    {
        isInteracting = true;
    }

    // Call this method to end an interaction.
    public void EndInteraction()
    {
        isInteracting = false;
    }
}
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