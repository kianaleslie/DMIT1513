using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraUserInputScript : MonoBehaviour
{
    //input variables
    public InputAction rotateAction;
    Vector2 rotateValue;
    float rotateSpeed;
    Keyboard kb;
    void Start()
    {
        rotateSpeed = 90.0f;
        kb = Keyboard.current;
    }

    void Update()
    {
        //get user input 
        rotateValue = rotateAction.ReadValue<Vector2>();

        //rotate camera 
        transform.Rotate(Vector3.up, rotateValue.x * rotateSpeed * Time.deltaTime, Space.World);
        if (kb.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }
    private void FixedUpdate()
    {
        //move the camera
        transform.Rotate(Vector3.up, rotateValue.y * rotateSpeed * Time.deltaTime);
    }
    private void OnEnable()
    {
        rotateAction.Enable();
    }
    private void OnDisable()
    {
        rotateAction.Disable();
    }
}