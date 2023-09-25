using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoverTankScript : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction rotateAction;
    Vector2 moveValue;
    Vector2 rotateValue;

    //force to move the tank 
    public float moveForce = 10.0f;
    //rotation speed to rotate the tank 
    public float rotateSpeed = 5.0f;
    //height for the tank to hover 
    public float hoverHeight = 1.0f;
    //force for which the tank hovers 
    public float hoverForce = 20.0f;
    public float maxGroundDistance = 1.5f;
    public float orientationSpeed = 2.0f;
    
    RaycastHit hit;

    private Rigidbody rbody;
    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        maxGroundDistance = 1.0f;
    }
    private void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        //hoverforce and something to hold the tanks mass

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