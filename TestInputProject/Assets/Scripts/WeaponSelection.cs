using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{
    public GameObject[] weaponPrefabs;
    public TMP_Text weaponNameText;
    public Transform weaponSpawnPoint; 
    private GameObject currentWeaponInstance;
    public Button next;
    public Button previous;

    private int currentWeaponIndex = 0;
    Mouse mouse;

    void Start()
    {
        next.onClick.AddListener(NextWeapon);
        previous.onClick.AddListener(PreviousWeapon);
        SpawnCurrentWeapon();
        mouse = Mouse.current;
    }

    void Update()
    {
        if (mouse.leftButton.wasPressedThisFrame) 
        {
            NextWeapon();
        }
        if (mouse.leftButton.wasPressedThisFrame) 
        {
            PreviousWeapon();
        }
    }

    void SpawnCurrentWeapon()
    {
        //destroy the current weapon if it exists
        if (currentWeaponInstance != null)
        {
            Destroy(currentWeaponInstance);
        }

        //instantiate the selected weapon prefab at the spawn point
        currentWeaponInstance = Instantiate(weaponPrefabs[currentWeaponIndex], weaponSpawnPoint.position, weaponSpawnPoint.rotation);

        //set the weapon's parent to the weaponSpawnPoint for proper positioning
        currentWeaponInstance.transform.parent = weaponSpawnPoint;

        //update the UI with the current weapon's name
        weaponNameText.text = weaponPrefabs[currentWeaponIndex].name;
    }

    public void NextWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex + 1) % weaponPrefabs.Length;
        SpawnCurrentWeapon();
    }

    public void PreviousWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex - 1 + weaponPrefabs.Length) % weaponPrefabs.Length;
        SpawnCurrentWeapon();
    }
}