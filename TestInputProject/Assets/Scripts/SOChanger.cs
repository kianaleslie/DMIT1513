using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SOChanger : MonoBehaviour
{
    [SerializeField] ScriptableObject[] scriptableObjects;
    [SerializeField] WeaponDisplay weaponDisplay;
    int currentIndex;

    private void Awake()
    {
        ChangeSO(0);
    }
    public void ChangeSO(int change)
    {
        currentIndex += change;

        if (currentIndex < 0)
        {
            currentIndex = scriptableObjects.Length - 1;
        }
        else
            if(currentIndex > scriptableObjects.Length)
        {
            currentIndex = 0; 
        }

        if(weaponDisplay != null)
        {
            weaponDisplay.DisplayWeapon((Weapon)scriptableObjects[currentIndex]);
        }
    }
}