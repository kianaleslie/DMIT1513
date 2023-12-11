using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using UnityEngine.InputSystem.LowLevel;

public class WeaponController : MonoBehaviour
{
    //public int[] inventory;
    //public GameObject[] weaponSlot;

    //private void Start()
    //{
    //    inventory = new int[4];
    //    weaponSlot = new GameObject[4];

    //    weaponSlot[0] = GameObject.FindGameObjectWithTag("Empty");
    //    weaponSlot[1] = GameObject.FindGameObjectWithTag("Weapon 1");
    //    weaponSlot[2] = GameObject.FindGameObjectWithTag("Weapon 2");
    //    weaponSlot[3] = GameObject.FindGameObjectWithTag("Weapon 3");
    ////}
    //public float range = 100f;
    //public float damage = 10f;
    //public Camera cam;
    //public ParticleSystem flash;
    ////public GameObject explosion;

    //private void Start()
    //{
    //    flash.Stop();
    //}
    //private void Update()
    //{
    //  if(Input.GetButtonDown("Fire1"))
    //    {
    //        Shoot();
    //    }
    //}
    //void Shoot()
    //{
    //    flash.Play();

    //    RaycastHit hit;
    //    if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
    //    {
    //        Target target = hit.transform.GetComponent<Target>();
    //        if(target != null)
    //        {
    //            target.TakeDamage(damage);
    //        }
    //    }
    //}
}