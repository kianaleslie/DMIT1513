using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] AudioSource explosionAudio;
    public ParticleSystem explosionSparks;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            StartCoroutine("Wait");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        //Destroy(gameObject);
        explosionAudio.Play();
        explosionSparks.Play();
    }
}