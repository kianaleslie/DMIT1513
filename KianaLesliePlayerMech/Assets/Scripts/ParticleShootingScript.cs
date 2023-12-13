using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ParticleShootingScript : MonoBehaviour
{
    public GameObject particleSystemObject;
    public AudioSource audioSource;
    [SerializeField] TMP_Text weaponText;
    public int currentAmmo = 200;
    Mouse mb;
    [SerializeField] ParticleSystem muzzelFlash;

    private void Start()
    {
        mb = Mouse.current;
        weaponText.text = "Ammo ";
    }
    private void Update()
    {
        if (mb.rightButton.wasPressedThisFrame)
        {
            Instantiate(particleSystemObject, transform.position, transform.rotation);
            audioSource.Play();
            muzzelFlash.Play();
            currentAmmo--;
        }
        UpdateAmmoText();
    }
    public void UpdateAmmoText()
    {
        weaponText.text = $"Ammo {currentAmmo}";
    }
}