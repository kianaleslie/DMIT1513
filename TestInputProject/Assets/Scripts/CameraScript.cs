using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float speed;
    float distance;
    float startPos;
    void Start()
    {
        speed = 2.0f;
        distance = 1.0f;
        startPos = transform.position.x;
    }
    void Update()
    {
        float newX = startPos + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}