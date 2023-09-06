using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    //variables
    public InputAction leftMovementAction;
    public InputAction rightMovementAction;
    Vector2 leftMoveValue;
    Vector2 rightMoveValue;
    float movementSpeed;
    void Start()
    {
        //intialize
        movementSpeed = 2.0f;
    }

    void Update()
    {
        //keyboard input 
        leftMoveValue = leftMovementAction.ReadValue<Vector2>();
        rightMoveValue = rightMovementAction.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        //move the object
        transform.Translate(new Vector3(leftMoveValue.x, 0, leftMoveValue.y) * movementSpeed * Time.deltaTime);
        transform.Translate(new Vector3(rightMoveValue.x, 0, rightMoveValue.y) * movementSpeed * Time.deltaTime);
    }
    private void OnEnable()
    {
        leftMovementAction.Enable();
        rightMovementAction.Enable();
    }
    private void OnDisable()
    {
        leftMovementAction.Disable();
        rightMovementAction.Disable();
    }
}