using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PaintballScript : MonoBehaviour
{
    public GameObject paintballPrefab;
    GameObject paintball;
    float pbSpeed = 1000.0f;
    Mouse mb;

    private void Start()
    {
        mb = Mouse.current;
    }
    private void Update()
    {
        //if (mb.leftButton.wasPressedThisFrame)
        // {
        //  Debug.Log("Mouse clicked");
        // }
        //left mouse button to fire paintballs
        if (mb.leftButton.wasPressedThisFrame)
        {
            //instantiate paintballs
            paintball = Instantiate(paintballPrefab, transform.position, transform.rotation);
            Rigidbody rb = paintball.GetComponent<Rigidbody>();

            //let them paintballs fly!!
            rb.AddForce(transform.forward * pbSpeed, ForceMode.Acceleration);
        }
    }
}