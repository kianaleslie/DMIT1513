using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
   [SerializeField] AudioSource explosionAudio;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            explosionAudio.Play();
            Destroy(collision.gameObject);
        }
    }
}