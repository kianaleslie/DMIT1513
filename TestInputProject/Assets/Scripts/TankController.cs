using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    //variables
    public InputAction leftMoveAction;
    public InputAction rightMoveAction;
    public InputAction rotateAction;
    public InputAction barrelAction;
    Vector2 leftMoveValue;
    Vector2 rightMoveValue;
    Vector2 rotateValue;
    Vector2 barrelValue;
    float moveSpeed;
    float rotateSpeed;
    [SerializeField] GameObject turret;
    [SerializeField] GameObject barrel;
    void Start()
    {
        //intialize
        moveSpeed = 1.0f;
        rotateSpeed = 360.0f;
    }

    void Update()
    {
        //keyboard input 
        leftMoveValue = leftMoveAction.ReadValue<Vector2>();
        rightMoveValue = rightMoveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();
        barrelValue = barrelAction.ReadValue<Vector2>();

        //rotate turret left/right and barrel up/down
        turret.transform.Rotate(Vector3.up, rotateValue.x * rotateSpeed * Time.deltaTime);
        barrel.transform.Rotate(Vector3.left, barrelValue.y * rotateSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //movement

        //both treads moving forward, tank moves at full speed
        if (rightMoveValue.y == moveSpeed && leftMoveValue.y == moveSpeed)
        {
            transform.Translate(new Vector3(rightMoveValue.x, 0, rightMoveValue.y) * moveSpeed * Time.deltaTime);
        }
        //one tread moving forward, tank moves at half speed
        else
        {
            transform.Translate(new Vector3(rightMoveValue.x, 0, rightMoveValue.y) * (moveSpeed / 2) * Time.deltaTime);
        }

        //both treads moving backward, tank moves at full speed
        if (rightMoveValue.y == -moveSpeed && leftMoveValue.y == -moveSpeed)
        {
            transform.Translate(new Vector3(leftMoveValue.x, 0, leftMoveValue.y) * moveSpeed * Time.deltaTime);
        }
        //one tread moving backward, tank moves at half speed
        else
        {
            transform.Translate(new Vector3(leftMoveValue.x, 0, leftMoveValue.y) * (moveSpeed / 2) * Time.deltaTime);
        }

        //rotation

        //right tread forward and left tread backward - rotate full speed left
        if (rightMoveValue.y == moveSpeed && leftMoveValue.y == -moveSpeed)
        {
            transform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime);
        }
        //right tread backward and left tread forward - rotate full speed right
        else
        if (rightMoveValue.y == -moveSpeed && leftMoveValue.y == moveSpeed)
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }

        //right tread forward and left tread not moving - rotate half speed left
        if (rightMoveValue.y == moveSpeed && leftMoveValue.y == 0)
        {
            transform.Rotate(Vector3.down, (rotateSpeed / 2) * Time.deltaTime);
        }
        //right tread not moving and left tread forward - rotate half speed right
        else
        if (rightMoveValue.y == 0 && leftMoveValue.y == moveSpeed)
        {
            transform.Rotate(Vector3.up, (rotateSpeed / 2) * Time.deltaTime);
        }

        //reverse the rotation
        if (rightMoveValue.y == -moveSpeed && leftMoveValue.y == 0)
        {
            transform.Rotate(Vector3.up, (rotateSpeed / 2) * Time.deltaTime);
        }
        if (rightMoveValue.y == 0 && leftMoveValue.y == -moveSpeed)
        {
            transform.Rotate(Vector3.down, (rotateSpeed / 2) * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        leftMoveAction.Enable();
        rightMoveAction.Enable();
        rotateAction.Enable();
        barrelAction.Enable();
    }
    private void OnDisable()
    {
        leftMoveAction.Disable();
        rightMoveAction.Disable();
        rotateAction.Disable();
        barrelAction.Disable();
    }
}