using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour
{
    [SerializeField] GameObject bucket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            other.transform.parent = bucket.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}