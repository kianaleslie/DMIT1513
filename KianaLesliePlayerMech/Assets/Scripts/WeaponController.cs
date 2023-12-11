using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int[] inventory;
    public GameObject[] weaponSlot;

    private void Start()
    {
        inventory = new int[4];
        weaponSlot = new GameObject[4];

        weaponSlot[0] = GameObject.FindGameObjectWithTag("Empty");
        weaponSlot[1] = GameObject.FindGameObjectWithTag("Weapon 1");
        weaponSlot[2] = GameObject.FindGameObjectWithTag("Weapon 2");
        weaponSlot[3] = GameObject.FindGameObjectWithTag("Weapon 3");
    }
}