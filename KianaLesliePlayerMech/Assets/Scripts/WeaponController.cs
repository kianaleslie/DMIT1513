using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using TMPro;

public class WeaponController : MonoBehaviour
{
    int slotSelected = 1;

    [SerializeField] GameObject firstSlot;
    [SerializeField] GameObject secondSlot;
    [SerializeField] GameObject thirdSlot;
    [SerializeField] GameObject fourthSlot;

    [SerializeField] TMP_Text eText;
    //[SerializeField] TMP_Text weaponText;
    [SerializeField] float distance = 5f;

    GameObject currentWeaponOnGround;
    //int currentAmmo = 100;

    private void Start()
    {
        SelectWeapon(slotSelected);
        eText.gameObject.SetActive(false);
        //weaponText.text = "";
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
        if (eText.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            PickUpWeapon();
        }

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    ReloadAmmo();
        //}

        //UpdateWeaponInfo();
    }
    void SwapSlot(int weaponType)
    {
        if (weaponType == 1)
        {
            firstSlot.SetActive(true);
            secondSlot.SetActive(false);
            thirdSlot.SetActive(false);
            fourthSlot.SetActive(false);
        }
        if (weaponType == 2)
        {
            firstSlot.SetActive(false);
            secondSlot.SetActive(true);
            thirdSlot.SetActive(false);
            fourthSlot.SetActive(false);
        }
        if (weaponType == 3)
        {
            firstSlot.SetActive(false);
            secondSlot.SetActive(false);
            thirdSlot.SetActive(true);
            fourthSlot.SetActive(false);
        }
        if (weaponType == 4)
        {
            firstSlot.SetActive(false);
            secondSlot.SetActive(false);
            thirdSlot.SetActive(false);
            fourthSlot.SetActive(true);
        }
    }
    void SelectWeapon(int weaponType)
    {
        slotSelected = weaponType;

        firstSlot.SetActive(false);
        secondSlot.SetActive(false);
        thirdSlot.SetActive(false);
        fourthSlot.SetActive(false);

        switch (weaponType)
        {
            case 1:
                firstSlot.SetActive(true);
                break;
            case 2:
                secondSlot.SetActive(true);
                break;
            case 3:
                thirdSlot.SetActive(true);
                break;
            case 4:
                fourthSlot.SetActive(true);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PickUpWeapon weaponPickup = other.GetComponent<PickUpWeapon>();
        if (weaponPickup != null)
        {
            eText.gameObject.SetActive(true);
            eText.text = "Press 'E' to pick up";
            currentWeaponOnGround = weaponPickup.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        eText.gameObject.SetActive(false);
        currentWeaponOnGround = null;
    }

    void PickUpWeapon()
    {
        eText.gameObject.SetActive(false);
        DropCurrentWeapon();
        SelectWeapon(slotSelected);
        currentWeaponOnGround = null;
    }

    void DropCurrentWeapon()
    {
        if (currentWeaponOnGround != null)
        {
            currentWeaponOnGround.transform.parent = null;
            currentWeaponOnGround.transform.position = transform.position + transform.forward * 2f;
            currentWeaponOnGround.SetActive(true);
        }
    }

    //void ReloadAmmo()
    //{
    //    int maxAmmo = 30; 
    //    currentAmmo = maxAmmo;
    //}

    //void UpdateWeaponInfo()
    //{
    //    weaponText.text = $"Slot {slotSelected}: Ammo {currentAmmo}";
    //}
}