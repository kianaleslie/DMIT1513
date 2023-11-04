using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawn : MonoBehaviour
{
    public ParticleSystem pS; 
    public float spawnInterval = 5.0f; 

    private void Start()
    {
        StartCoroutine(SpawnParticles());
    }

    private IEnumerator SpawnParticles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            pS.Play();
            yield return new WaitForSeconds(0.5f);
            pS.Stop();
        }
    }
}