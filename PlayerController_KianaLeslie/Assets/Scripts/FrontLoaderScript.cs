using UnityEngine;
using UnityEngine.InputSystem;

public class FrontLoaderScript : MonoBehaviour
{
    //input and movement variables 
    public InputAction moveAction;
    public InputAction rotateAction;
    public InputAction armAction;
    public InputAction bucketAction;

    Vector2 moveValue;
    Vector2 rotateValue;
    Vector2 armValue;
    Vector2 bucketValue;
    Vector2 angles;

    float moveSpeed;
    float rotateSpeed;

    [SerializeField] GameObject arm;
    [SerializeField] GameObject bucket;

    Keyboard kb;

    void Start()
    {
        //initalize movement variables
        moveSpeed = 3.0f;
        rotateSpeed = 100.0f;
    }
    void Update()
    {
        //get player input 
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();
        armValue = armAction.ReadValue<Vector2>();
        bucketValue = bucketAction.ReadValue<Vector2>();

        //rotate turret left/right and barrel up/down
        
        bucket.transform.Rotate(Vector3.left, bucketValue.y * rotateSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //move and rotate loader
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotateValue.x * rotateSpeed * Time.deltaTime);


        arm.transform.Rotate(Vector3.up, rotateValue.y * rotateSpeed * Time.deltaTime);
       // angles = arm.transform.localRotation.eulerAngles;

        //clamp arms 60 degrees up
        if (angles.x > 25 && angles.x < 90)
        {
            arm.transform.localRotation = Quaternion.Euler(25.0f, 0, 0);
        }

        //and 25 degrees down
        if (angles.x < 300 && angles.x > 270)
        {
            arm.transform.localRotation = Quaternion.Euler(300.0f, 0, 0);
        }


        bucket.transform.Rotate(Vector3.right, rotateValue.y * rotateSpeed * Time.deltaTime);
        //angles = bucket.transform.localRotation.eulerAngles;

        //clamp bucket rotation 40 degrees up 
        if (angles.x > 70 && angles.x < 90)
        {
            bucket.transform.localRotation = Quaternion.Euler(70.0f, 0, 0);
        }
        //and 70 degrees down
        if (angles.x < 320 && angles.x > 270)
        {
            bucket.transform.localRotation = Quaternion.Euler(320.0f, 0, 0);
        }


        //if (kb.escapeKey.wasPressedThisFrame)
        //{
        //    Application.Quit();
        //}
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
