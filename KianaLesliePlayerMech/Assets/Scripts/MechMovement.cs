using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem.HID;
using Unity.VisualScripting;

public class MechMovement : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction baseRotationAction;
    public InputAction torsoRotationAction;

    Vector2 moveValue;
    Vector2 baseRotationValue;
    Vector2 torsoRotationValue;
    Vector2 angles;
    Vector2 shoulderAngles;

    float moveSpeed;
    float rotateSpeed;


    [SerializeField] AudioSource loopingSound;

    [SerializeField] GameObject torsoGameObject;
    [SerializeField] GameObject baseGameObject;
    [SerializeField] GameObject leftShoulderObject;
    [SerializeField] GameObject rightShoulderObject;

    public InputAction shootAction;
    public WeaponOneController weaponController;

    [SerializeField] GameObject uiObject;

    void Start()
    {
        moveSpeed = 10.0f;
        rotateSpeed = 150.0f;

        
        uiObject.SetActive(false);
    }
    void Update()
    {
        Move();

        if (shootAction.WasPressedThisFrame())
        {
            weaponController.Fire();  
        }
    }
    private void FixedUpdate()
    {
        //move mech
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ammo")
        {
            weaponController.currentAmmo += 50;
            weaponController.UpdateAmmoText();
            collision.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GroundWeapon"))
        {
            uiObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GroundWeapon"))
        {
            uiObject.SetActive(false);
        }
    }
    void Move()
    {
        //get input
        moveValue = moveAction.ReadValue<Vector2>();
        baseRotationValue = baseRotationAction.ReadValue<Vector2>();
        torsoRotationValue = torsoRotationAction.ReadValue<Vector2>();

        //rotation and clamping
        transform.Rotate(Vector3.up, baseRotationValue.x * rotateSpeed * Time.deltaTime);

        TorsoRotation();
        ShoulderRotation();

        //movement sound
        if (moveValue.magnitude > 0f && !loopingSound.isPlaying)
        {
            loopingSound.Play();
        }
        else
            if (moveValue.magnitude == 0f && loopingSound.isPlaying)
        {
            loopingSound.Stop();
        }
    }
    void TorsoRotation()
    {
        float verticleInput = Input.GetAxis("Mouse X");

        torsoGameObject.transform.Rotate(Vector3.up, verticleInput * rotateSpeed * Time.deltaTime);

        angles = torsoGameObject.transform.localEulerAngles;
        if (angles.y < 270.0f && angles.y > 90.0f)
        {
            if (angles.y > 180.0f)
            {
                torsoGameObject.transform.localRotation = Quaternion.Euler(0, 270.0f, 0);
            }
            else
            {
                torsoGameObject.transform.localRotation = Quaternion.Euler(0, 90.0f, 0);
            }
        }
    }
    void ShoulderRotation()
    {
        float horizontialInput = Input.GetAxis("Mouse Y");

        leftShoulderObject.transform.Rotate(Vector3.left, horizontialInput * rotateSpeed * Time.deltaTime);
        rightShoulderObject.transform.Rotate(Vector3.left, horizontialInput * rotateSpeed * Time.deltaTime);

        shoulderAngles = leftShoulderObject.transform.localEulerAngles;
        if (shoulderAngles.x > 45.0f && shoulderAngles.x < 180.0f)
        {
            leftShoulderObject.transform.localRotation = Quaternion.Euler(45.0f, 0, 0);
            rightShoulderObject.transform.localRotation = Quaternion.Euler(45.0f, 0, 0);
        }
        if (shoulderAngles.x < 315.0f && shoulderAngles.x > 180.0f)
        {
            leftShoulderObject.transform.localRotation = Quaternion.Euler(315.0f, 0, 0);
            rightShoulderObject.transform.localRotation = Quaternion.Euler(315.0f, 0, 0);
        }
    }
    private void OnEnable()
    {
        moveAction.Enable();
        baseRotationAction.Enable();
        torsoRotationAction.Enable();
        shootAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        baseRotationAction.Disable();
        torsoRotationAction.Disable();
        shootAction.Disable();
    }
}