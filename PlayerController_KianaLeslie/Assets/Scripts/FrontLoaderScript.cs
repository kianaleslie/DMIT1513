using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class FrontLoaderScript : MonoBehaviour
{
    //input and movement variables 
    public InputAction moveAction;
    public InputAction rotateAction;

    public InputAction armRotationAction;
    public InputAction bucketRotationAction;

    Vector2 moveValue;
    Vector2 rotateValue;
    Vector2 armRotateValue;
    Vector2 bucketRotateValue;

    Vector3 angles;

    float moveSpeed;
    float rotateSpeed;

    [SerializeField] GameObject arm;
    [SerializeField] GameObject bucket;

    void Start()
    {
        //initalize movement variables
        moveSpeed = 3.0f;
        rotateSpeed = 80.0f;
    }
    void Update()
    {
        //get player input 
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();

        armRotateValue = armRotationAction.ReadValue<Vector2>();
        bucketRotateValue = bucketRotationAction.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        //clamp rotation of arms 60 degrees up and 25 degrees down
        arm.transform.Rotate(Vector3.forward, armRotateValue.y * rotateSpeed * Time.deltaTime);
        //arm.transform.Rotate(Vector3.right, armValue.x * rotateSpeed * Time.deltaTime);
        angles = arm.transform.localRotation.eulerAngles;
        if (angles.z > 60.0f && angles.z < 90.0f)
        {
            arm.transform.localRotation = Quaternion.Euler(0, 0, 60.0f);
        }
        if (angles.z < 335.0f && angles.z > 270.0f)
        {
            arm.transform.localRotation = Quaternion.Euler(0, 0, 335.0f);
        }

        //clamp the rotation of the bucket 40 degrees up and 70 degrees down  
        bucket.transform.Rotate(Vector3.left, bucketRotateValue.y * rotateSpeed * Time.deltaTime);
        //bucket.transform.Rotate(Vector3.left, bucketValue.x * rotateSpeed * Time.deltaTime);
        angles = bucket.transform.localRotation.eulerAngles;
        if (angles.x > 70.0f && angles.x < 90.0f)
        {
            bucket.transform.localRotation = Quaternion.Euler(70.0f, 90, 0);
        }
        if (angles.x < 320.0f && angles.x > 270.0f)
        {
            bucket.transform.localRotation = Quaternion.Euler(320.0f, 90, 0);
        }

        //move and rotate loader
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotateValue.x * rotateSpeed * Time.deltaTime);   
    }
    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();

        armRotationAction.Enable();
        bucketRotationAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();

        armRotationAction.Disable();
        bucketRotationAction.Disable();
    }
}