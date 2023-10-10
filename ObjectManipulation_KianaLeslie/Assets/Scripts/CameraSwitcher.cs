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
        if (kb.pKey.wasPressedThisFrame && topDownCam.enabled == true)
        {
            isFirstPersonView = !isFirstPersonView;

            thirdPersonCam.enabled = isFirstPersonView;
            firstPersonCam.enabled = !isFirstPersonView;
        }
    }
}