using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonFireScript : MonoBehaviour
{
    public GameObject cannonballPrefab;
    GameObject cannonBall;
    float cbSpeed = 1000.0f;
    Keyboard kb;
    [SerializeField] AudioSource shootAudio;
    public ParticleSystem fireSparks;

    private void Start()
    {
        kb = Keyboard.current;
    }
    private void Update()
    {
        if (kb.spaceKey.wasPressedThisFrame)
        {
            //instantiate cannon balls
            cannonBall = Instantiate(cannonballPrefab, transform.position, transform.rotation);
            Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * cbSpeed, ForceMode.Acceleration);
            shootAudio.Play();
            fireSparks.Play();
        }
        if(kb.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }
}
//ref for article system https://www.youtube.com/watch?v=rf7gHVixmmc