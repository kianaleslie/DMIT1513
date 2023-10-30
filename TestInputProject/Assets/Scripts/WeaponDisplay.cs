using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text weaponName;
    [SerializeField] Transform weaponHolder;
    public void DisplayWeapon(Weapon weapon)
    {
        weaponName.text = weapon.weaponText;

       if (weaponHolder.childCount > 0)
        {
            Destroy(weaponHolder.GetChild(0).gameObject);
        }
        Instantiate(weapon.weaponModel, weaponHolder.position, weaponHolder.rotation, weaponHolder);
    }
}