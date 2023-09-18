using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        rb = collision.transform.GetComponent<Rigidbody>();

        if (rb != null)
        {
            var speed = collision.relativeVelocity.y / 1.1f;
            rb.velocity = new Vector3(rb.velocity.x, -speed, rb.velocity.z);
        }
    }
    //Ming helped me a bit with this exercise.
}