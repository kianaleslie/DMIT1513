using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VendingMachineScript : MonoBehaviour
{
    public GameObject weaponSelectUI;

    Keyboard kb;
    private bool weaponSelectUIActive = false;

    private void Start()
    {
        kb = Keyboard.current;
        weaponSelectUI.SetActive(false);
    }
    void Update()
    {
        if (kb.eKey.wasPressedThisFrame)
        {
            weaponSelectUIActive = !weaponSelectUIActive; 
            weaponSelectUI.SetActive(weaponSelectUIActive);
        }
    }
}