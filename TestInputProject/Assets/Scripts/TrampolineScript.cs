using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    Rigidbody rb;
    float jumpRate = 1.1f;

    private void OnCollisionEnter(Collision collision)
    {
        rb = collision.transform.GetComponent<Rigidbody>();

        if (rb != null)
        {
            var speed = collision.relativeVelocity.y / jumpRate;
            rb.velocity = new Vector3(rb.velocity.x, -speed, rb.velocity.z);
        }
    }
}