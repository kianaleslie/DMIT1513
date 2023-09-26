using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoverTankScript : MonoBehaviour
{
    //input variables
    public InputAction moveAction;
    public InputAction rotateAction;
    Vector2 moveValue;
    Vector2 rotateValue;

    //rotation speed to rotate the tank 
    float moveSpeed;
    float rotateSpeed;
    //force for which the tank hovers 
    float hoverForce;
    float maxGroundDistance;

    RaycastHit hit;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxGroundDistance = 2.0f;
        rotateSpeed = 80.0f;
        moveSpeed = 5.0f;
    }
    private void Update()
    {
        //player input
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        //move and rotate the tank 
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotateValue.x * rotateSpeed * Time.deltaTime);

        //the hover force is the rigidbody mass 
        hoverForce = rb.mass;

       // rb.AddForce(Vector3.forward * (moveValue.x + moveValue.y) * moveSpeed);
       //tank hovers using raycast and addforce
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxGroundDistance))
        {
            rb.AddForce(transform.up * (maxGroundDistance - hit.distance) / maxGroundDistance * hoverForce, ForceMode.Impulse);
        }
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