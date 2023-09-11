using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    //variables
    public InputAction leftMoveAction;
    public InputAction rightMoveAction;
    public InputAction rotateA;
    Vector2 leftMoveValue;
    Vector2 rightMoveValue;
    Vector2 rotateV;
    float moveSpeed;
    float rotateS;
    [SerializeField] GameObject turret;
    void Start()
    {
        //intialize
        moveSpeed = 2.0f;
        rotateS = 100.0f;
    }

    void Update()
    {
        //keyboard input 
        leftMoveValue = leftMoveAction.ReadValue<Vector2>();
        rightMoveValue = rightMoveAction.ReadValue<Vector2>();
        rotateV = rotateA.ReadValue<Vector2>();

        turret.transform.Rotate(Vector3.right, rotateV.y * rotateS * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //move the object
        transform.Translate(new Vector3(leftMoveValue.x, 0, leftMoveValue.y) * moveSpeed * Time.deltaTime);
        transform.Translate(new Vector3(rightMoveValue.x, 0, rightMoveValue.y) * moveSpeed * Time.deltaTime);

        turret.transform.Rotate(Vector3.right, rotateV.y * rotateS * Time.deltaTime);
    }
    private void OnEnable()
    {
        leftMoveAction.Enable();
        rightMoveAction.Enable();
        rotateA.Enable();
    }
    private void OnDisable()
    {
        leftMoveAction.Disable();
        rightMoveAction.Disable();
        rotateA.Disable();
    }
}