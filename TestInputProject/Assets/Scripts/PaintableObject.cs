using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableObject : MonoBehaviour
{
    public Material paintedMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paintball"))
        {
            // Change the material/color of the object
            GetComponent<Renderer>().material = paintedMaterial;

            // Destroy the paintball
            Destroy(collision.gameObject);
        }
    }
}
