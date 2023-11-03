using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light flickeringLight;
    public float minTime = 0.1f;
    public float maxTime = 0.5f;
    public float timer;

    public void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }
    public void Update()
    {
        FlickerLight();
    }
    void FlickerLight()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            flickeringLight.enabled = !flickeringLight.enabled;
            timer = Random.Range(minTime, maxTime);
        }
    }
}