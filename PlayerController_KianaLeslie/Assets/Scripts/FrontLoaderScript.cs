using UnityEngine;
using UnityEngine.InputSystem;

public class FrontLoaderScript : MonoBehaviour
{
    //input variables 
    public InputAction moveAction;
    public InputAction rotateAction;

    Vector2 moveValue;
    Vector2 rotateValue;
    Vector2 angles;

    float moveSpeed;
    float rotateSpeed;

    [SerializeField] GameObject arm;
    [SerializeField] GameObject bucket;

    Keyboard kb;
    void Start()
    {
        moveSpeed = 3.0f;
        rotateSpeed = 100.0f;
    }
    void Update()
    {
        //get player input 
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        arm.transform.Rotate(Vector3.up, rotateValue.x * rotateSpeed * Time.deltaTime);
        angles = arm.transform.localRotation.eulerAngles;
        if (angles.x > 25 && angles.x < 90)
        {
            arm.transform.localRotation = Quaternion.Euler(25.0f, 0, 0);
        }
        if (angles.x < 300 && angles.x > 270)
        {
            arm.transform.localRotation = Quaternion.Euler(300.0f, 0, 0);
        }


        bucket.transform.Rotate(Vector3.right, rotateValue.y * rotateSpeed * Time.deltaTime);
        angles = bucket.transform.localRotation.eulerAngles;
        if (angles.x > 70 && angles.x < 90)
        {
            bucket.transform.localRotation = Quaternion.Euler(70.0f, 0, 0);
        }
        if (angles.x < 320 && angles.x > 270)
        {
            bucket.transform.localRotation = Quaternion.Euler(320.0f, 0, 0);
        }


        if (kb.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }
}
