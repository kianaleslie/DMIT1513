using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraBehaviour : MonoBehaviour
{
    public Camera thirdPersonCam;
    public Camera firstPersonCam;
    bool isFirstPersonView = false;

    Keyboard kb;

    void Start()
    {
        kb = Keyboard.current;
        thirdPersonCam.enabled = true;
        firstPersonCam.enabled = false;
    }
    void Update()
    {
        if (kb.pKey.wasPressedThisFrame)
        {
            isFirstPersonView = !isFirstPersonView;

            thirdPersonCam.enabled = isFirstPersonView;
            firstPersonCam.enabled = !isFirstPersonView;
        }
    }
}