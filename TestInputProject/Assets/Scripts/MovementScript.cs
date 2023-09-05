using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    //input variables
    public InputAction moveA;
    Vector2 move;
    //movement variables
    float moveS;
    void Start()
    {
        //initalize movement variable
        moveS = 2.0f;
    }

    void Update()
    {
        //get player input 
        move = moveA.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        //move the object
        transform.Translate(new Vector3(move.x, 0, move.y) * moveS * Time.deltaTime);
    }
    private void OnEnable()
    {
        moveA.Enable();
    }
    private void OnDisable()
    {
        moveA.Disable();
    }
}