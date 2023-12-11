using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem.HID;

public class MechMovement : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction baseRotationAction;
    public InputAction torsoRotationAction;

    Vector2 moveValue;
    Vector2 baseRotationValue;
    Vector2 torsoRotationValue;
    Vector2 angles;

    float moveSpeed;
    float baseRotateSpeed;
    float torsoRotateSpeed;

    AudioSource loopingSound;

    [SerializeField] GameObject torsoGameObject;
    [SerializeField] GameObject baseGameObject;

    public InputAction shootAction;

    void Start()
    {
        moveSpeed = 10.0f;
        baseRotateSpeed = 150.0f;
        torsoRotateSpeed = 150.0f;

        loopingSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        Move();

        if (shootAction.WasPressedThisFrame())
        {
            BroadcastMessage("Fire");
        }
    }
    private void FixedUpdate()
    {
        //move mech
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
       
    }
    void Move()
    {
        //get input
        moveValue = moveAction.ReadValue<Vector2>();
        baseRotationValue = baseRotationAction.ReadValue<Vector2>();
        torsoRotationValue = torsoRotationAction.ReadValue<Vector2>();

        //rotation and clamping
        transform.Rotate(Vector3.up, baseRotationValue.x * baseRotateSpeed * Time.deltaTime);

        torsoGameObject.transform.Rotate(Vector3.up, torsoRotationValue.x * torsoRotateSpeed * Time.deltaTime);

        angles = torsoGameObject.transform.eulerAngles;

        if (angles.x > 270.0f && angles.x < 90.0f)
        {
            torsoGameObject.transform.localRotation = Quaternion.Euler(270.0f, 0, 0);
        }

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