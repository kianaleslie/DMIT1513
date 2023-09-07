using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    //variables
    public InputAction leftMovementAction;
    public InputAction rightMovementAction;
    public InputAction rotateA;
    Vector2 leftMoveValue;
    Vector2 rightMoveValue;
    Vector2 rotateV;
    float movementSpeed;
    float rotateS;
    [SerializeField] GameObject turret;
    void Start()
    {
        //intialize
        movementSpeed = 2.0f;
        rotateS = 100.0f;
    }

    void Update()
    {
        //keyboard input 
        leftMoveValue = leftMovementAction.ReadValue<Vector2>();
        rightMoveValue = rightMovementAction.ReadValue<Vector2>();
        rotateV = rotateA.ReadValue<Vector2>();

        turret.transform.Rotate(Vector3.right, rotateV.y * rotateS * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //move the object
        transform.Translate(new Vector3(leftMoveValue.x, 0, leftMoveValue.y) * movementSpeed * Time.deltaTime);
        transform.Translate(new Vector3(rightMoveValue.x, 0, rightMoveValue.y) * movementSpeed * Time.deltaTime);

        turret.transform.Rotate(Vector3.right, rotateV.y * rotateS * Time.deltaTime);
    }
    private void OnEnable()
    {
        leftMovementAction.Enable();
        rightMovementAction.Enable();
        rotateA.Enable();
    }
    private void OnDisable()
    {
        leftMovementAction.Disable();
        rightMovementAction.Disable();
        rotateA.Disable();
    }
}