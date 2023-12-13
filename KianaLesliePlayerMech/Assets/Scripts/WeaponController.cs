using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using TMPro;

public class WeaponController : MonoBehaviour
{
    int slotSelected;

    [SerializeField] GameObject firstSlot;
    [SerializeField] GameObject secondSlot;
    [SerializeField] GameObject thirdSlot;
    [SerializeField] GameObject fourthSlot;

    [SerializeField] TMP_Text activeWeapon;
    string activeWeaponName;

    enum Weapon
    {
        Caliber,
        Sniper,
        Shotgun,
        Empty
    }
    Weapon weapon = Weapon.Empty;
    private void Start()
    {
        firstSlot.SetActive(false);
        secondSlot.SetActive(false);
        thirdSlot.SetActive(false);
        fourthSlot.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (slotSelected != 1)
            {
                SwapSlot(1);
                slotSelected = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (slotSelected != 2)
            {
                SwapSlot(2);
                slotSelected = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (slotSelected != 3)
            {
                SwapSlot(3);
                slotSelected = 3;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (slotSelected != 4)
            {
                SwapSlot(4);
                slotSelected = 4;
            }
        }
        activeWeapon.text = $"Active Weapon: {activeWeaponName}";

        switch (weapon)
        {
            case Weapon.Caliber:
                slotSelected = 1;
                activeWeaponName = "Caliber";
                break;
            case Weapon.Sniper:
                slotSelected = 2;
                activeWeaponName = "Sniper";
                break;
            case Weapon.Shotgun:
                slotSelected = 3;
                activeWeaponName = "Shotgun";
                break;
            case Weapon.Empty:
                slotSelected = 4;
                activeWeaponName = "Empty Slot";
                break;
        }
    }
    void SwapSlot(int weaponType)
    {
        if (weaponType == 1)
        {
            firstSlot.SetActive(true);
            secondSlot.SetActive(false);
            thirdSlot.SetActive(false);
            fourthSlot.SetActive(false);
            weapon = Weapon.Empty;
        }
        if (weaponType == 2)
        {
            firstSlot.SetActive(false);
            secondSlot.SetActive(true);
            thirdSlot.SetActive(false);
            fourthSlot.SetActive(false);
            weapon = Weapon.Shotgun;
        }
        if (weaponType == 3)
        {
            firstSlot.SetActive(false);
            secondSlot.SetActive(false);
            thirdSlot.SetActive(true);
            fourthSlot.SetActive(false);
            weapon = Weapon.Sniper;
        }
        if (weaponType == 4)
        {
            firstSlot.SetActive(false);
            secondSlot.SetActive(false);
            thirdSlot.SetActive(false);
            fourthSlot.SetActive(true);
            weapon = Weapon.Caliber;
        }
    }
}