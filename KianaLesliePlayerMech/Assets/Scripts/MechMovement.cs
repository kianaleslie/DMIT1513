using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MechMovement : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction baseRotationAction;
    public InputAction torsoRotationAction;

    Vector2 moveValue;
    Vector2 baseRotationValue;
    Vector2 torsoRotationValue;
    //Vector2 angles; 

    float moveSpeed;
    float baseRotateSpeed;
    float torsoRotateSpeed;
   

    void Start()
    {
        moveSpeed = 12.0f;
        baseRotateSpeed = 150.0f;
        torsoRotateSpeed = 150.0f;
    }
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        baseRotationValue = baseRotationAction.ReadValue<Vector2>();
        torsoRotationValue = torsoRotationAction.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, baseRotationValue.y * baseRotateSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, torsoRotationValue.y * torsoRotateSpeed * Time.deltaTime);
    }
    private void OnEnable()
    {
        moveAction.Enable();
        baseRotationAction.Enable();
        torsoRotationAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        baseRotationAction.Disable();
        torsoRotationAction.Disable();
    }
}