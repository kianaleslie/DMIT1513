using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    void Start()
    {
        moveSpeed = 10.0f;
        baseRotateSpeed = 150.0f;
        torsoRotateSpeed = 150.0f;

        loopingSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        baseRotationValue = baseRotationAction.ReadValue<Vector2>();
        torsoRotationValue = torsoRotationAction.ReadValue<Vector2>();

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
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, baseRotationValue.x * baseRotateSpeed * Time.deltaTime);

        torsoGameObject.transform.Rotate(Vector3.up, torsoRotationValue.x * torsoRotateSpeed * Time.deltaTime);

        angles = torsoGameObject.transform.eulerAngles;

        if (angles.x > 270.0f && angles.x < 90.0f)
        {
            torsoGameObject.transform.localRotation = Quaternion.Euler(270.0f, 0, 0);
        }
    }

    private void OnEnable()
    {
        moveAction.Enable();
        baseRotationAction.Enable();
        torsoRotationAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        baseRotationAction.Disable();
        torsoRotationAction.Disable();
    }
}