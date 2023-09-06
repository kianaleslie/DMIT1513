using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    //input variables
    public InputAction moveAction;
    public InputAction rotateAction;
    Vector2 moveValue;
    Vector2 rotateValue;
    //movement variables
    float moveSpeed;
    float rotateSpeed;
    [SerializeField] GameObject weapon;
    void Start()
    {
        //initalize movement variable
        moveSpeed = 2.0f;
        rotateSpeed = 100.0f;
    }

    void Update()
    {
        //get player input 
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();

        //rotate player and weapon 
        transform.Rotate(Vector3.up, rotateValue.x * rotateSpeed * Time.deltaTime);

        weapon.transform.Rotate(Vector3.right, rotateValue.y * rotateSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //leftMoveValue the object
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotateValue.y * rotateSpeed * Time.deltaTime);
        weapon.transform.Rotate(Vector3.right, rotateValue.y * rotateSpeed * Time.deltaTime);
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