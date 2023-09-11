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
    Vector2 angles;
    //movement variables
    float moveSpeed;
    float rotateSpeed;
    bool touchingGround = true;
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

        //rotate player and tank 
        transform.Rotate(Vector3.up, rotateValue.x * rotateSpeed * Time.deltaTime);
        weapon.transform.Rotate(Vector3.right, rotateValue.y * rotateSpeed * Time.deltaTime);
        //get current angles
        angles = weapon.transform.eulerAngles;
        //check if angles need to be clamped 
        if (angles.x > 45.0f && angles.x < 180.0f)
        {
            weapon.transform.localRotation = Quaternion.Euler(45.0f, 0, 0); 
        }
        if (angles.x < 315.0f && angles.x > 180.0f)
        {
            weapon.transform.rotation = Quaternion.Euler(315.0f, 0, 0);
        }
        var kB = Keyboard.current;
        if(kB != null)
        {
            if(kB.spaceKey.wasPressedThisFrame && touchingGround)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 300.0f * Time.deltaTime, ForceMode.Impulse/*VelocityChange*/);
                touchingGround = false;
            }
        }
    }
    private void FixedUpdate()
    {
        //move the object
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
    //private void OnTriggerEnter(Collider other)
    //{
    //    touchingGround = true;
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    touchingGround = false;
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            touchingGround = true;
        }
    }
}