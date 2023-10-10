using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet;
    float bulletSpeed = 0.5f;
    Mouse mb;

    private void Start()
    {
        mb = Mouse.current;
    }
    private void Update()
    {
        //left mouse button to fire bullets
        if (mb.leftButton.wasPressedThisFrame)
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * bulletSpeed, ForceMode.Acceleration);
        }
    }
}