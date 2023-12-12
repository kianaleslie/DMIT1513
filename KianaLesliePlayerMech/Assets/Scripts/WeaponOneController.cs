using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponOneController : MonoBehaviour
{
    int bulletAmount;
    int poolCount;
    int index;
    float fireRate;
    float velocity;
    float timeStamp;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    [SerializeField] GameObject[] bullets;

    int currentAmmo = 20;
    [SerializeField] TMP_Text weaponText;
    [SerializeField] AudioClip sound;
    AudioSource audioSource;

    void Start()
    {
        bulletAmount = 200;
        poolCount = 5;
        fireRate = 0.5f;
        velocity = 25.0f;

        weaponText.text = "Ammo ";
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound;

        GameObject instantiatedObject;

        bullets = new GameObject[poolCount];

        for (int i = 0; i < bullets.Length; i++)
        {
            instantiatedObject = Instantiate(bullet);
            instantiatedObject.SetActive(false);
            bullets[i] = instantiatedObject;
            Physics.IgnoreCollision(GetComponentInChildren<Collider>(), instantiatedObject.GetComponentInChildren<Collider>());
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadAmmo();
        }
        UpdateAmmoText();
    }
    void Fire()
    {
        if (bulletAmount > 0 && currentAmmo > 0 && Time.time > timeStamp + fireRate)
        {
            timeStamp = Time.time;
            bulletAmount--;
            currentAmmo--;

            bullets[index].transform.position = bulletSpawn.transform.position;
            bullets[index].transform.rotation = bulletSpawn.transform.rotation;
            bullets[index].SetActive(true);
            bullets[index].GetComponent<Rigidbody>().velocity = transform.forward * velocity;

            audioSource.Play();

            index++;

            if (index >= poolCount)
            {
                index = 0;
            }
        }
    }
    void ReloadAmmo()
    {
        int maxAmmo = 20;
        currentAmmo = maxAmmo;
    }
    void UpdateAmmoText()
    {
        weaponText.text = $"Ammo {currentAmmo}";
    }
}