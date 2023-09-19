using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMovement : MonoBehaviour
{
    public InputAction moveAction;
    Vector2 moveValue;
    float moveSpeed;
    float movementForce;
    float rotationForce;
    Rigidbody rb;
    void Start()
    {
        
    }
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
        rb.AddRelativeForce(Vector3.forward * movementForce);
        rb.AddRelativeTorque(Vector3.up * rotationForce * Time.fixedDeltaTime * (moveValue.y - moveValue.x), ForceMode.Acceleration);
    }
    private void OnEnable()
    {
        moveAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
    }
}