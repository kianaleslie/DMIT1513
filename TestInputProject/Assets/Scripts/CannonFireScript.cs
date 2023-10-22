using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonFireScript : MonoBehaviour
{
    //public GameObject cannonballPrefab;
    //GameObject cannonBall;
    //float cbSpeed = 1000.0f;
    //Keyboard kb;
    //[SerializeField] AudioSource shootAudio;

    //private void Start()
    //{
    //    kb = Keyboard.current;
    //}
    //private void Update()
    //{
    //    if (kb.spaceKey.wasPressedThisFrame)
    //    {
    //        //instantiate cannon balls
    //        cannonBall = Instantiate(cannonballPrefab, transform.position, transform.rotation);
    //        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
    //        rb.AddForce(transform.forward * cbSpeed, ForceMode.Acceleration);
    //        shootAudio.Play();
    //    }
    //}
    public float recoilForce = 1000f; // Adjust this value to control the strength of the recoil.

    [SerializeField] Rigidbody rb;
    private Vector3 initialPosition;
    Keyboard kb;
    [SerializeField] AudioSource shootAudio;
    public GameObject cannonballPrefab;
    //GameObject cannonBall;
    //float cbSpeed = 1000.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        kb = Keyboard.current;
    }

    void Update()
    {
        if (kb.spaceKey.wasPressedThisFrame)
        {
            //instantiate cannon balls
            //cannonBall = Instantiate(cannonballPrefab, transform.position, transform.rotation);
            //Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * cbSpeed, ForceMode.Acceleration);
            FireCannon();
            shootAudio.Play();
        }
    }

    void FireCannon()
    {
        // Apply recoil force in the backward direction.
        rb.AddForce(-transform.forward * recoilForce);
    }

    void FixedUpdate()
    {
        // Reset the cannon's position after a delay to mimic the recoil effect.
        if (transform.position != initialPosition)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime);
        }
    }
}