using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction rotateAction;
    Vector2 moveValue;
    Vector2 rotateValue;
    Vector2 angles;
    float moveSpeed;
    float rotateSpeed;
    [SerializeField] GameObject cameraRotation;
    public bool instructions = false;
    public GameObject instructionsUI;
    public GameObject eKey;

    void Start()
    {
        moveSpeed = 10.0f;
        rotateSpeed = 150.0f;
        instructionsUI.SetActive(false);
        eKey.SetActive(true);
    }
    void Update()
    { 
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();

        transform.Rotate(Vector3.up, rotateValue.x * rotateSpeed * Time.deltaTime);

        cameraRotation.transform.Rotate(Vector3.right, rotateValue.y * rotateSpeed * Time.deltaTime);
        //get current angles
        angles = cameraRotation.transform.localEulerAngles;
        //check if angles need to be clamped 
        if (angles.x > 45.0f && angles.x < 180.0f)
        {
            cameraRotation.transform.localRotation = Quaternion.Euler(45.0f, 0, 0);
        }
        if (angles.x < 315.0f && angles.x > 180.0f)
        {
            cameraRotation.transform.localRotation = Quaternion.Euler(315.0f, 0, 0);
        }

        if(instructionsUI != null)
        {
            instructions = !instructions;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (instructions == true)
                {
                    ToggleInstructionsOn();
                }
                else
                {
                    ToggleInstructionsOff();
                }
            }
        }  
    }
    void ToggleInstructionsOn()
    {
        instructions = true;
        instructionsUI.SetActive(true);
        eKey.SetActive(false);
    }
    void ToggleInstructionsOff()
    {
        instructions = false;
        instructionsUI.SetActive(false);
        eKey.SetActive(false);
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotateValue.y * rotateSpeed * Time.deltaTime);
    }
    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
    }
}