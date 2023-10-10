using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletScript : MonoBehaviour
{
    int damage = 10;
    private void OnCollisionEnter(Collision collision)
    {
        HealthUI health = collision.gameObject.GetComponent<HealthUI>();
        if (health != null)
        {
            health.DealDamage(damage);
        }

        gameObject.SetActive(false);
    }

    //followed my paintball exercise - wasn't working
    //public GameObject bulletPrefab;
    //GameObject bullet;
    //float bulletSpeed = 0.5f;
    //Mouse mb;
    //EnemyScript enemyHealth;

    //private void Start()
    //{
    //    mb = Mouse.current;
    //}
    //private void Update()
    //{
    //    //left mouse button to fire bullets
    //    if (mb.leftButton.wasPressedThisFrame)
    //    {
    //        bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    //        Rigidbody rb = bullet.GetComponent<Rigidbody>();
    //        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Acceleration);
    //    }
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        enemyHealth.TakeDamage(10);
    //    }
    //    Destroy(gameObject);
    //}
}